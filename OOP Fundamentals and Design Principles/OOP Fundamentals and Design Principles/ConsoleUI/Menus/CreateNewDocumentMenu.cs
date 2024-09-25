using CabinetLibrary;

namespace ConsoleUI
{
   public class CreateNewDocumentMenu
   {
      private static ILibraryDocument? LibraryDocument { get; set; }
      private static Type? LibraryDocumentType { get; set; }
      public static void DisplayMenu(ICreateNewDocumentPrompt createNewDocumentPrompt)
      {
         LibraryDocument = createNewDocumentPrompt.PopulateData();
         LibraryDocumentType = createNewDocumentPrompt.GetLibraryDocumentType();
         Console.WriteLine();
         Console.WriteLine("1 - Save");
         Console.WriteLine(". - Go back to Main Menu");
         ConvertCommand();
      }

      private static void ConvertCommand()
      {
         var input = Console.ReadLine();
         switch (input)
         {
            case "1":
               Save();
               break;
            case ".":
               CommandPerformer.Perform(Command.DisplayMainMenu);
               break;
            default:
               Console.WriteLine("Incorect input!");
               Console.ReadLine();
               CommandPerformer.Perform(Command.CreateLibDoc);
               break;
         }
      }

      private static void Save()
      {
         var bookHandler = Start.LibraryDocumentStorageServiceCache;
         if (LibraryDocument != null && LibraryDocumentType != null)
         {
            bookHandler?.SaveLibraryDocument(LibraryDocument, LibraryDocumentType, LibraryDocument.DocumentNumber);
            Console.WriteLine($"Document with the document number {LibraryDocument.DocumentNumber} was saved successfully!");
            Initialize();
            Console.ReadLine();
            CommandPerformer.Perform(Command.DisplayMainMenu);
         }
         else
         {
            Console.WriteLine($"Operation was not successful!");
            Console.ReadLine();
            CommandPerformer.Perform(Command.DisplayMainMenu);
         }
      }

      private static void Initialize()
      {
         LibraryDocument = null;
         LibraryDocumentType = null;
      }

   }
}
