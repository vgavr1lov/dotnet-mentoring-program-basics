namespace CabinetLibrary
{
   public class Book : LibraryDocument, IBook
   {
      public List<string> Authors { get; set; } = new List<string>();
      public string ISBN { get; set; }
      public int NumberOfPages { get; set; }
      public string PublishedDate { get; set; }
      public string Publisher { get; set; }

      public Book() { }
      public Book(IBook book)
      {
         DocumentNumber = book.DocumentNumber;
         Title = book.Title;
         Authors = book.Authors;
         ISBN = book.ISBN;
         NumberOfPages = book.NumberOfPages;
         PublishedDate = book.PublishedDate;
         Publisher = book.Publisher;
      }      
   }

}
