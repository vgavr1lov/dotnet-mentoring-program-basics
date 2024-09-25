using CabinetLibrary;

namespace ConsoleUI
{
   public class SearchLibraryDocumentByDocumentNumberMenu
   {
      public static void DisplayMenu()
      {
         var documentNumber = EnterDocumentNumber();
         Console.Clear();
         DisplayLibraryDocument(documentNumber);
      }

      private static string? EnterDocumentNumber()
      {
         Console.Write("Enter Document Number: ");
         return Console.ReadLine();
      }

      private static void DisplayLibraryDocument(string? documentNumber)
      {
         if (string.IsNullOrWhiteSpace(documentNumber))
         {
            StandardOutputMessages.OutputNoDocumentNumberEntered();
            Console.Clear();
            DisplayLibraryDocumentMenu.DisplayMenu();
         }

         var storageHandler = Start.LibraryDocumentStorageServiceCache;
         try
         {
            var libraryDocument = storageHandler?.ReadLibraryDocumentByDocumentNumber(documentNumber);
            if (libraryDocument == null)
            {
               StandardOutputMessages.OutputNothingFoundByDocumentNumber(documentNumber);
               return;
            }
            DisplayLibraryDocumentMenu.DisplayLibraryDocument(libraryDocument.GetType(), libraryDocument);
         }
         catch (Exception ex)
         {
            StandardOutputMessages.OutputErrorMessage(ex.Message);
         }
         finally
         {
            Console.Clear();
            DisplayLibraryDocumentMenu.DisplayMenu();
         }
      }
   }


}
