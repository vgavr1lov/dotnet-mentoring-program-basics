namespace CabinetLibrary
{
   public class ConsoleMagazinePrinter : IPrinter
   {
      public void Print(ILibraryDocument libraryDocument)
      {
         var magazine = libraryDocument as IMagazine;
         Console.WriteLine($"Document type: {magazine?.GetType().Name}");
         Console.WriteLine($"Document number: {magazine?.DocumentNumber}");
         Console.WriteLine($"Title: {magazine?.Title}");
         Console.WriteLine($"Release number: {magazine?.ReleaseNumber}");
         Console.WriteLine($"Published Date: {magazine?.PublishedDate}");
         Console.WriteLine($"Publisher: {magazine?.PublishedDate}");
      }
   }
}
