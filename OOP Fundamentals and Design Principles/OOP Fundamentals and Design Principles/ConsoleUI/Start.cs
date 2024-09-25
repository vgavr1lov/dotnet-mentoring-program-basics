using CabinetLibrary;
using Microsoft.Extensions.Caching.Memory;
using System.Configuration;

namespace ConsoleUI
{
   public class Start
   {
      public static IStorageHandler? LibraryDocumentStorageServiceCache { get; private set; }
      public static void ActivateStorageServiceCache()
      {
         var cacheConfigurationItems = ReadCacheSetting();
         LibraryDocumentStorageServiceCache = Factory.CreateStorageHandler(new MemoryCache(new MemoryCacheOptions()), cacheConfigurationItems);

      }

      private static List<IFileStorageCacheConfigurationItem> ReadCacheSetting()
      {
         var appSettings = ConfigurationManager.AppSettings;
         var cacheConfigurationItems = new List<IFileStorageCacheConfigurationItem>();
         foreach (var singleKey in appSettings.AllKeys)
         {
            var cacheConfigurationItem = Factory.CreateFileStorageCacheConfigurationItem();
            cacheConfigurationItem.documentType = singleKey;
            cacheConfigurationItem.cacheConfiguration = appSettings[singleKey];
            cacheConfigurationItems.Add(cacheConfigurationItem);
         }

         return cacheConfigurationItems;
      }

   }
}
