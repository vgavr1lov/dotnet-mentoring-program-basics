namespace ConsoleUI
{
   public static class CommandPerformer
   {
      public static void Perform(Command command)
      {
         switch (command)
         {
            case Command.CreateLibDoc:
               Console.Clear();
               CreateLibraryDocumentMenu.DisplayMenu();
               break;
            case Command.DisplayLibDoc:
               Console.Clear();
               DisplayLibraryDocumentMenu.DisplayMenu();
               break;
            case Command.DisplayAllLibDocs:
               Console.Clear();
               DisplayLibraryDocumentMenu.DisplayAllLibraryDocuments();
               break;
            case Command.DisplayMainMenu:
               Console.Clear();
               MainMenu.DisplayMenu(); 
               break;
            case Command.SearchByDocNum:
               Console.Clear();
               SearchLibraryDocumentByDocumentNumberMenu.DisplayMenu();
               break;
            case Command.CreateBook:
               Console.Clear();
               CreateNewDocumentMenu.DisplayMenu(new CreateBookPrompt());
               break;
            case Command.CreateLocalizedBook:
               Console.Clear();
               CreateNewDocumentMenu.DisplayMenu(new CreateLocalizedBookPrompt());
               break;
            case Command.CreatePatent:
               Console.Clear();
               CreateNewDocumentMenu.DisplayMenu(new CreatePatentPrompt());
               break;
            case Command.CreateMagazine:
               Console.Clear();
               CreateNewDocumentMenu.DisplayMenu(new CreateMagazinePrompt());
               break;
         }
      }
   }
}
