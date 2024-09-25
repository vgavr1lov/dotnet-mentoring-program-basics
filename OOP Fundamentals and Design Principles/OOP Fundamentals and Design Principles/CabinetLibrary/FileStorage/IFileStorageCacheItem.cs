namespace CabinetLibrary
{
   public interface IFileStorageCacheItem
   {
      Type? DocumentType { get; set; }
      string? JsonString { get; set; }
   }
}