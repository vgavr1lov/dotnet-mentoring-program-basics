using CabinetLibrary;

namespace ConsoleUI
{
   public static class ConsolePrinter
   {
      public static IPrinter DetermineConsolePrinter(Type type)
      {
         switch (type.Name)
         {
            case nameof(Book):
               return Factory.CreateBookPrinter();
            case nameof(LocalizedBook):
               return Factory.CreateLocalizedBookPrinter();
            case nameof(Patent):
               return Factory.CreatePatentPrinter();
            case nameof(Magazine):
               return Factory.CreateMagazinePrinter();
            default:
               throw new NotImplementedException();
         }
      }

      public static void Print(IPrinter printer, ILibraryDocument libraryDocument)
      {
         printer.Print(libraryDocument);
      }
   }
}
