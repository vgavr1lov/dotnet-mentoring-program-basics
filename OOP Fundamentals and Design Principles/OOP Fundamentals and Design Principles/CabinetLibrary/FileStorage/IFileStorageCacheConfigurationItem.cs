namespace CabinetLibrary
{
   public interface IFileStorageCacheConfigurationItem
   {
      string? cacheConfiguration { get; set; }
      string? documentType { get; set; }
   }
}