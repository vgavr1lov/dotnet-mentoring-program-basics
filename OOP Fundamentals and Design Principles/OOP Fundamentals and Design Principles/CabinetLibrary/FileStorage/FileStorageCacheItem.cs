namespace CabinetLibrary
{
   public class FileStorageCacheItem : IFileStorageCacheItem
   {
      public string? JsonString { get; set; }
      public Type? DocumentType { get; set; }
   }
}
