namespace HarryPotterKata
{
   public class HarryPotterBookshop
   {
      private const double NoDiscount = 0.00;
      private const double TwoBooksDiscount = 0.05;
      private const double ThreeBooksDiscount = 0.1;
      private const double FourBooksDiscount = 0.2;
      private const double FiveBooksDiscount = 0.25;
      public double CalculateBaketCost(Book[] basket)
      {
         var bundles = SortBooksIntoBundles(basket);
         var basketCost = bundles.Sum(CalculatePriceForBundle);

         return basketCost;
      }

      private double CalculatePriceForBundle(Bundle bundle)
      {
         return bundle.BundleCost - CalculateDiscount(bundle.BundleCount, bundle.BundleCost);
      }

      private double CalculateDiscount(int numberOfQuniqueBooks, double discountBase)
      {
         switch (numberOfQuniqueBooks)
         {
            case 2:
               return discountBase * TwoBooksDiscount;
            case 3:
               return discountBase * ThreeBooksDiscount;
            case 4:
               return discountBase * FourBooksDiscount;
            case 5:
               return discountBase * FiveBooksDiscount;
            default:
               return NoDiscount;
         }
      }

      private List<Bundle> SortBooksIntoBundles(Book[] baket)
      {
         List<Bundle> bundles = new List<Bundle>();

         foreach (Book book in baket)
         {
            if (bundles.Count == 0)
            {
               var bundle = new Bundle();
               bundle.Add(book);
               bundles.Add(bundle);
            }
            else
            {
               var bundle = bundles.FirstOrDefault(x => x.CheckBookNotInBundle(book));
               if (bundle != null)
               {
                  bundle.Add(book);
               }
               else
               {
                  bundle = new Bundle();
                  bundle.Add(book);
                  bundles.Add(bundle);
               }
            }
         }

         return bundles;
      }

      private class Bundle
      {
         private const int MaxNumberInBundle = 5;

         private int[] bundle = new int[MaxNumberInBundle];
         public double BundleCost { get; private set; }
         public int BundleCount { get; private set; }
         public void Add(Book book)
         {
            bundle[BundleCount] = book.BookNumber;
            BundleCost += book.BookPrice;
            BundleCount++;
         }

         public bool CheckBookNotInBundle(Book book)
         {
            if (bundle.Any(x => x.Equals(book.BookNumber)))
               return false;

            return true;
         }
      }
   }
}
