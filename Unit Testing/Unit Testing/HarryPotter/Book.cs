namespace HarryPotterKata
{
   public class Book
   {
      public int BookNumber { get; init; }
      public double BookPrice { get; init; }
      public string PriceCurrency { get; init; }

      public const double Price = 8.0;
      public const string Currency = "EUR";
      public Book(int bookNumber)
      {
         if (bookNumber < 1 || bookNumber > 5)
            throw new ArgumentOutOfRangeException($"{nameof(BookNumber)} - The book number should be 1 to 5");
         //throw new ArgumentOutOfRangeException();


         BookNumber = bookNumber;
         BookPrice = Price;
         PriceCurrency = Currency;
      }
   }
}
