namespace ConsoleUI
{
   public static class MainMenu
   {
      public static void DisplayMenu()
      {
         Console.WriteLine("Main Menu:");
         Console.WriteLine("1 - Create Library Document");
         Console.WriteLine("2 - Display Library Document");
         ConvertCommand();
      }

      private static void ConvertCommand()
      {
         var input = Console.ReadLine();
         switch (input)
         {
            case "1":
               CommandPerformer.Perform(Command.CreateLibDoc);
               break;
            case "2":
               CommandPerformer.Perform(Command.DisplayLibDoc);
               break;
            default:
               CommandPerformer.Perform(Command.DisplayMainMenu);
               break;
         }
      }
   }
}
