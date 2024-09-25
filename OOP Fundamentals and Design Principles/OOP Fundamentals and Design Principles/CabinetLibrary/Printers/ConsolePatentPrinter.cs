namespace CabinetLibrary
{
   public class ConsolePatentPrinter : IPrinter
   {
      public void Print(ILibraryDocument libraryDocument)
      {
         var patent = libraryDocument as IPatent;
         Console.WriteLine($"Document type: {patent?.GetType().Name}");
         Console.WriteLine($"Document number: {patent?.DocumentNumber}");
         Console.WriteLine($"Title: {patent?.Title}");
         Console.WriteLine($"Authors:");
         foreach (var author in patent!.Authors)
         {
            Console.WriteLine(author);
         }
         Console.WriteLine($"Published Date: {patent?.PublishedDate}");
         Console.WriteLine($"Expiration Date: {patent?.ExpirationDate}");
         Console.WriteLine($"Unique ID: {patent?.UniqueID}");
      }
   }
}
