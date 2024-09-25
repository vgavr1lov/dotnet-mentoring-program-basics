using Microsoft.Extensions.Caching.Memory;

namespace CabinetLibrary
{
   public static class Factory
   {
      public static IBook CreateBook()
      {
         return new Book();
      }
      public static ILocalizedBook CreateLocalizedBook()
      {
         return new LocalizedBook();
      }

      public static IPatent CreatePatent()
      {
         return new Patent();
      }
      public static IMagazine CreateMagazine()
      {
         return new Magazine();
      }
      public static IPrinter CreateBookPrinter()
      {
         return new ConsoleBookPrinter();
      }
      public static IPrinter CreateLocalizedBookPrinter()
      {
         return new ConsoleLocalizedBookPrinter();
      }
      public static IPrinter CreatePatentPrinter()
      {
         return new ConsolePatentPrinter();
      }
      public static IPrinter CreateMagazinePrinter()
      {
         return new ConsoleMagazinePrinter();
      }
      public static IStorageHandler CreateStorageHandler(IMemoryCache memoryCache, List<IFileStorageCacheConfigurationItem> fileStorageCacheConfigurationItems)
      {
         return new FileStorageHandler(memoryCache, fileStorageCacheConfigurationItems);
      }
      public static IStorageDocumentNumberGenerator CreateStorageDocumentNumberGenerator()
      {
         return new FileStorageDocumentNumberGenerator();
      }

      public static IFileStorageCacheItem CreateFileStorageCacheItem()
      {
         return new FileStorageCacheItem();
      }

      public static IFileStorageCacheConfigurationItem CreateFileStorageCacheConfigurationItem()
      {
         return new FileStorageCacheConfigurationItem();
      }
   }
}
