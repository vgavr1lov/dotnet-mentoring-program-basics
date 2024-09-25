using CabinetLibrary;

namespace ConsoleUI
{
   public class CreatePatentPrompt : ICreateNewDocumentPrompt
   {
      public ILibraryDocument PopulateData()
      {
         var patent = Factory.CreatePatent();
         patent.DocumentNumber = Factory.CreateStorageDocumentNumberGenerator().GenerateDocumentNumber();
         Console.WriteLine("Enter Title:");
         patent.Title = GetUserInput();
         Console.WriteLine("Enter Author or enter . to continue:");
         EnterAuthors(patent);
         Console.WriteLine("Enter Published Date:");
         patent.PublishedDate = GetUserInput();
         Console.WriteLine("Enter Expiration Date:");
         patent.ExpirationDate = GetUserInput();
         Console.WriteLine("Enter Unique ID:");
         patent.UniqueID = GetUserInput();

         return patent;
      }

      public Type GetLibraryDocumentType()
      {
         return typeof(Patent);
      }

      private void EnterAuthors(IPatent book)
      {
         var input = GetUserInput();
         if (input == ".")
            return;
         book!.Authors.Add(input);
         EnterAuthors(book);
      }

      private string GetUserInput()
      {
         var input = Console.ReadLine();
         if (String.IsNullOrWhiteSpace(input))
            input = GetUserInput();

         return input!;
      }

      private int GetUserInputInt()
      {
         var input = Console.ReadLine();
         if (String.IsNullOrWhiteSpace(input))
            input = GetUserInput();


         int inputParsed;

         if (int.TryParse(input, out inputParsed))
         {
            return inputParsed;
         }

         return GetUserInputInt();
      }

   }
}
