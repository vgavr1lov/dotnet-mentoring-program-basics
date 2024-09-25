namespace ConsoleUI
{
   public class CreateLibraryDocumentMenu
   {
      public static void DisplayMenu()
      {
         Console.WriteLine("Choose Library Document type to create:");
         Console.WriteLine("1 - Book");
         Console.WriteLine("2 - Localized Book");
         Console.WriteLine("3 - Patent");
         Console.WriteLine("4 - Magazine");
         Console.WriteLine(". - Go back to Main Menu");
         ConvertCommand();
      }

      private static void ConvertCommand()
      {
         var input = Console.ReadLine();
         switch (input)
         {
            case "1":
               CommandPerformer.Perform(Command.CreateBook);
               break;
            case "2":
               CommandPerformer.Perform(Command.CreateLocalizedBook);
               break;
            case "3":
               CommandPerformer.Perform(Command.CreatePatent);
               break;
            case "4":
               CommandPerformer.Perform(Command.CreateMagazine);
               break;
            case ".":
               CommandPerformer.Perform(Command.DisplayMainMenu);
               break;
            default:
               CommandPerformer.Perform(Command.CreateLibDoc);
               break;
         }
      }
   }
}
