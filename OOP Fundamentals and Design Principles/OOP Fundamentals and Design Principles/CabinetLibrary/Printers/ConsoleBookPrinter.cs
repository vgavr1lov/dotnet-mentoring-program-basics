namespace CabinetLibrary
{
   public class ConsoleBookPrinter : IPrinter
   {
      public void Print(ILibraryDocument libraryDocument)
      {
         var book = libraryDocument as IBook;
         Console.WriteLine($"Document type: {book?.GetType().Name}");
         Console.WriteLine($"Document number: {book?.DocumentNumber}");
         Console.WriteLine($"Title: {book?.Title}");
         Console.WriteLine($"ISBN: {book?.ISBN}");
         Console.WriteLine($"Number of pages: {book?.NumberOfPages}");
         Console.WriteLine($"Authors:");
         foreach (var author in book!.Authors)
         {
            Console.WriteLine(author);
         }
         Console.WriteLine($"Publisher: {book?.Publisher}");
         Console.WriteLine($"Published Date: {book?.PublishedDate}");
      }
   }
}
