using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace CabinetLibrary
{
   public class FileStorageHandler : IStorageHandler
   {
      private IMemoryCache MemoryCache { get; set; }
      private List<IFileStorageCacheConfigurationItem> CacheConfigurationItems { get; set; }
      public FileStorageHandler(IMemoryCache memoryCache, List<IFileStorageCacheConfigurationItem> cacheConfigurationItems)
      {
         MemoryCache = memoryCache;
         CacheConfigurationItems = cacheConfigurationItems;
      }
      public static string FileMask { get; private set; } = "_#";
      public static string FileExtension { get; private set; } = ".json";
      public static string FileStorageFolder { get; private set; } = "Library\\";
      public void SaveLibraryDocument(ILibraryDocument storedLibraryDocument, Type type, string documentNumber)
      {
         var jsonSerializationFileName = $"{FileStorageFolder}{type.Name}{FileMask}{documentNumber}{FileExtension}";
         var jsonString = JsonSerializer.Serialize(storedLibraryDocument, type);
         CacheData(documentNumber, jsonString, type!);
         File.WriteAllText(jsonSerializationFileName, jsonString);
      }
      public string[]? GetAllLibraryDocuments()
      {
         var fileMask = $"*{FileMask}*{FileExtension}";
         var files = Directory.GetFiles(FileStorageFolder, fileMask, SearchOption.TopDirectoryOnly);

         if (files == null)
            throw new FileNotFoundException($"No files were not found!");

         return files.Select(f => Path.GetFileNameWithoutExtension(f)).ToArray();
      }
      public ILibraryDocument? ReadLibraryDocumentByDocumentNumber(string documentNumber)
      {
         if (!TryGetCacheData(documentNumber, out string? jsonString, out Type? documentType))
         {
            var fileName = SearchByDocumentNumber(documentNumber);
            jsonString = ReadFile(fileName);
            documentType = DetermineType(fileName);
            CacheData(documentNumber, jsonString, documentType!);
         }

         return DeserializeJsonString(jsonString!, documentType!);
      }

      private void CacheData(string documentNumber, string jsonString, Type documentType)
      {
         var cachedItem = Factory.CreateFileStorageCacheItem();
         cachedItem.JsonString = jsonString;
         cachedItem.DocumentType = documentType;
         var minutes = GetCacheTimeInMinutes(documentType);
         if (minutes == 0)
            return; //do not cache
         MemoryCache.Set(documentNumber, cachedItem, TimeSpan.FromMinutes(minutes));

      }

      private int GetCacheTimeInMinutes(Type documentType)
      {
         var cacheConfigurationValue = CacheConfigurationItems
             .Where(i => i.documentType == documentType.Name)
             .Select(i => i.cacheConfiguration)
             .FirstOrDefault();
        
         return int.TryParse(cacheConfigurationValue, out var minutes) ? minutes : 0;
      }

      private bool TryGetCacheData(string documentNumber, out string? jsonString, out Type? documentType)
      {

         var cachedItem = MemoryCache.Get(documentNumber) as IFileStorageCacheItem;
         if (cachedItem != null)
         {
            jsonString = cachedItem.JsonString;
            documentType = cachedItem.DocumentType;
            return true;
         }

         jsonString = null;
         documentType = null;
         return false;
      }

      private string ReadFile(string fileName)
      {
         return File.ReadAllText(fileName);
      }

      private Type? DetermineType(string fileName)
      {
         var parsedFileName = Path.GetFileName(fileName);
         var typeName = $"{GetType().Namespace}.{parsedFileName.Split("_")[0]}";
         var documentType = Type.GetType(typeName);
         if (documentType == null)
            throw new TypeLoadException($"The system couldn't recognize the type {typeName}");
         return documentType;
      }

      private ILibraryDocument? DeserializeJsonString(string jsonString, Type documentType)
      {
         return JsonSerializer.Deserialize(jsonString, documentType) as ILibraryDocument;
      }

      private string SearchByDocumentNumber(string documentNumber)
      {
         var fileMask = $"*{FileMask}{documentNumber}{FileExtension}";
         var files = Directory.GetFiles(FileStorageFolder, fileMask, SearchOption.TopDirectoryOnly);

         if (files.Length == 0)
            throw new FileNotFoundException($"The file with Document Number {documentNumber} was not found!");

         if (files.Length > 1)
         {
            throw new ArgumentOutOfRangeException($"More than one file with Document Number {documentNumber} exists!");
         }

         return files[0];
      }


   }
}
