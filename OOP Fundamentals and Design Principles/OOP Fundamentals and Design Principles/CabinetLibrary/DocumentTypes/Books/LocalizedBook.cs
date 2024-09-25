namespace CabinetLibrary
{
   public class LocalizedBook : LibraryDocument, ILocalizedBook
   {
      public List<string> Authors { get; set; } = new List<string>();
      public string ISBN { get; set; }
      public int NumberOfPages { get; set; }
      public string PublishedDate { get; set; }
      public string OriginalPublisher { get; set; }
      public string CountryOfLocalization { get; set; }
      public string LocalPublisher { get; set; }

      public LocalizedBook() { }
      public LocalizedBook(ILocalizedBook localizedBook)
      {
         DocumentNumber = localizedBook.DocumentNumber;
         Title = localizedBook.Title;
         Authors = localizedBook.Authors;
         ISBN = localizedBook.ISBN;
         NumberOfPages = localizedBook.NumberOfPages;
         PublishedDate = localizedBook.PublishedDate;
         OriginalPublisher = localizedBook.OriginalPublisher;
         CountryOfLocalization = localizedBook.CountryOfLocalization;
         LocalPublisher = localizedBook.LocalPublisher;
      }
   }
}
