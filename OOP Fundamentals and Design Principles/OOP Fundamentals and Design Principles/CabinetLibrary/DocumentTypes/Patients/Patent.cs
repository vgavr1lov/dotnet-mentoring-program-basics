namespace CabinetLibrary
{
   public class Patent : LibraryDocument, IPatent
   {
      public List<string> Authors { get; set; } = new List<string>();
      public string PublishedDate { get; set; }
      public string ExpirationDate { get; set; }
      public string UniqueID { get; set; }

      public Patent() { }
      public Patent(IPatent patent)
      {
         DocumentNumber = patent.DocumentNumber;
         Title = patent.Title;
         Authors = patent.Authors;
         PublishedDate = patent.PublishedDate;
         ExpirationDate = patent.ExpirationDate;
         UniqueID = patent.UniqueID;
      }
   }
}
