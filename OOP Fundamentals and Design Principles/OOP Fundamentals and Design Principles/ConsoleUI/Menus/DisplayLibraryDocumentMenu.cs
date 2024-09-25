using CabinetLibrary;

namespace ConsoleUI
{
   public static class DisplayLibraryDocumentMenu
   {
      public static void DisplayMenu()
      {
         Console.WriteLine("Display Library Document:");
         Console.WriteLine("1 - Display all Library Documents");
         Console.WriteLine("2 - Search by Document Number");
         Console.WriteLine(". - Go back to Main Menu");
         ConvertCommand();
      }

      private static void ConvertCommand()
      {
         var input = Console.ReadLine();
         switch (input)
         {
            case "1":
               CommandPerformer.Perform(Command.DisplayAllLibDocs);
               break;
            case "2":
               CommandPerformer.Perform(Command.SearchByDocNum);
               break;
            case ".":
               CommandPerformer.Perform(Command.DisplayMainMenu);
               break;
            default:
               CommandPerformer.Perform(Command.DisplayLibDoc);
               break;
         }
      }

      public static void DisplayLibraryDocument(Type type, ILibraryDocument libraryDocument)
      {
         var printer = ConsolePrinter.DetermineConsolePrinter(libraryDocument.GetType());
         ConsolePrinter.Print(printer, libraryDocument);
         Console.ReadLine();
      }

      public static void DisplayAllLibraryDocuments()
      {
         var storageHandler = Start.LibraryDocumentStorageServiceCache;

         try
         {
            var libraryDocuments = storageHandler?.GetAllLibraryDocuments();
            if (libraryDocuments == null)
            {
               StandardOutputMessages.OutputNothingFound();
               return;
            }
            foreach (var libraryDocument in libraryDocuments)
            {
               Console.WriteLine(libraryDocument);
            }
         }
         catch (Exception ex)
         {
            StandardOutputMessages.OutputErrorMessage(ex.Message);
         }
         finally
         {
            Console.ReadLine();
            Console.Clear();
            DisplayLibraryDocumentMenu.DisplayMenu();
         }
      }

   }
}
