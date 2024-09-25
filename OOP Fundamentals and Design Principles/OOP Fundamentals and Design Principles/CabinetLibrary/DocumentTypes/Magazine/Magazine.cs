namespace CabinetLibrary
{
   public sealed class Magazine : LibraryDocument, IMagazine
   {
      public string Publisher { get; set; }
      public string PublishedDate { get; set; }
      public string ReleaseNumber { get; set; }

      public Magazine() { }
      public Magazine(IMagazine magazine)
      {
         DocumentNumber = magazine.DocumentNumber;
         Title = magazine.Title;
         ReleaseNumber = magazine.ReleaseNumber;
         PublishedDate = magazine.PublishedDate;
         Publisher = magazine.Publisher;
      }
   }
}
