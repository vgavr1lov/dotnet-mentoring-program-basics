using CabinetLibrary;

namespace ConsoleUI
{
   public class CreateBookPrompt : ICreateNewDocumentPrompt
   {
      public ILibraryDocument PopulateData()
      {
         var book = Factory.CreateBook();
         book.DocumentNumber = Factory.CreateStorageDocumentNumberGenerator().GenerateDocumentNumber();
         Console.WriteLine("Enter Title:");
         book.Title = GetUserInput();
         Console.WriteLine("Enter ISBN:");
         book.ISBN = GetUserInput();
         Console.WriteLine("Enter Author or enter . to continue:");
         EnterAuthors(book);
         Console.WriteLine("Enter number of pages:");
         book.NumberOfPages = GetUserInputInt();
         Console.WriteLine("Enter Publisher:");
         book.Publisher = GetUserInput();
         Console.WriteLine("Enter Published Date:");
         book.PublishedDate = GetUserInput();

         return book;
      }

      public Type GetLibraryDocumentType()
      {
         return typeof(Book);
      }

      private void EnterAuthors(IBook book)
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
