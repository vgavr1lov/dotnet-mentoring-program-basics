using System;

namespace CabinetLibrary
{
   public class ConsoleLocalizedBookPrinter : IPrinter
   {
      public void Print(ILibraryDocument libraryDocument)
      {
         var localizedBook = libraryDocument as ILocalizedBook;
         Console.WriteLine($"Document type: {localizedBook?.GetType().Name}");
         Console.WriteLine($"Document number: {localizedBook?.DocumentNumber}");
         Console.WriteLine($"Title: {localizedBook?.Title}");
         Console.WriteLine($"ISBN: {localizedBook?.ISBN}");
         Console.WriteLine($"Number of pages: {localizedBook?.NumberOfPages}");
         Console.WriteLine($"Authors:");
         foreach (var author in localizedBook!.Authors)
         {
            Console.WriteLine(author);
         }
         Console.WriteLine($"Published date: {localizedBook?.PublishedDate}");
         Console.WriteLine($"Original publisher: {localizedBook?.OriginalPublisher}");
         Console.WriteLine($"Country of localization: {localizedBook?.CountryOfLocalization}");
         Console.WriteLine($"Local publisher: {localizedBook?.LocalPublisher}");

      }
   }
}
