using CabinetLibrary;

namespace ConsoleUI
{
   public class CreateLocalizedBookPrompt : ICreateNewDocumentPrompt
   {
      public ILibraryDocument PopulateData()
      {
         var localizedBook = Factory.CreateLocalizedBook();
         localizedBook.DocumentNumber = Factory.CreateStorageDocumentNumberGenerator().GenerateDocumentNumber();
         Console.WriteLine("Enter Title:");
         localizedBook.Title = GetUserInput();
         Console.WriteLine("Enter ISBN:");
         localizedBook.ISBN = GetUserInput();
         Console.WriteLine("Enter Author or enter . to continue:");
         EnterAuthors(localizedBook);
         Console.WriteLine("Enter number of pages:");
         localizedBook.NumberOfPages = GetUserInputInt();
         Console.WriteLine("Enter Published Date:");
         localizedBook.PublishedDate = GetUserInput();
         Console.WriteLine("Enter Original Publisher:");
         localizedBook.OriginalPublisher = GetUserInput();
         Console.WriteLine("Enter Country of localization:");
         localizedBook.CountryOfLocalization = GetUserInput(); ;
         Console.WriteLine("Enter Local Publisher:");
         localizedBook.LocalPublisher = GetUserInput(); ;

         return localizedBook;
      }

      public Type GetLibraryDocumentType()
      {
         return typeof(LocalizedBook);
      }

      private void EnterAuthors(ILocalizedBook book)
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
