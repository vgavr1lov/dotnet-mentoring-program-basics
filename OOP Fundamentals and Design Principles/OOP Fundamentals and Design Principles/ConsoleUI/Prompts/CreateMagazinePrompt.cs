using CabinetLibrary;

namespace ConsoleUI
{
   public class CreateMagazinePrompt : ICreateNewDocumentPrompt
   {
      public ILibraryDocument PopulateData()
      {
         var magazine = Factory.CreateMagazine();
         magazine.DocumentNumber = Factory.CreateStorageDocumentNumberGenerator().GenerateDocumentNumber();
         Console.WriteLine("Enter Title:");
         magazine.Title = GetUserInput();
         Console.WriteLine("Enter Release number:");
         magazine.ReleaseNumber = GetUserInput();
         Console.WriteLine("Enter Publisher:");
         magazine.Publisher = GetUserInput();
         Console.WriteLine("Enter Published Date:");
         magazine.PublishedDate = GetUserInput();

         return magazine;
      }

      public Type GetLibraryDocumentType()
      {
         return typeof(Magazine);
      }
      private string GetUserInput()
      {
         var input = Console.ReadLine();
         if (String.IsNullOrWhiteSpace(input))
            input = GetUserInput();

         return input!;
      }
   }
}
