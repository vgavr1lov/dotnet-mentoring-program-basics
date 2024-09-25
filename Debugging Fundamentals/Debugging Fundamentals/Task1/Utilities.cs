using System;

namespace Task1
{
   public static class Utilities
   {
      /// <summary>
      /// Sorts an array in ascending order using bubble sort.
      /// </summary>
      /// <param name="numbers">Numbers to sort.</param>
      public static void Sort(int[] numbers)
      {
         if (numbers == null)                            // <- fix
            throw new ArgumentNullException();           // <- fix

         int temp;
         for (int i = 0; i < numbers.Length; i++)
         {
            //for (int j = i; j < numbers.Length; j++)   // <- fix
            for (int j = i + 1; j < numbers.Length; j++)
            {
               //if (numbers[i] < numbers[j])     
               if (numbers[i] > numbers[j])              // <- fix
               {
                  temp = numbers[i];
                  // numbers[i] = temp;                  // <- fix
                  // numbers[j] = numbers[i];            // <- fix
                  numbers[i] = numbers[j];
                  numbers[j] = temp;
               }
            }
         }
      }

      /// <summary>
      /// Searches for the index of a product in an <paramref name="products"/> 
      /// based on a <paramref name="predicate"/>.
      /// </summary>
      /// <param name="products">Products used for searching.</param>
      /// <param name="predicate">Product predicate.</param>
      /// <returns>If match found then returns index of product in <paramref name="products"/>
      /// otherwise -1.</returns>
      public static int IndexOf(Product[] products, Predicate<Product> predicate)
      {
         if (products == null || predicate == null)      // <- fix
            throw new ArgumentNullException();           // <- fix

         //for (int i = 0; i < products.Length - 1; i++)   
         for (int i = 0; i < products.Length; i++)       // <- fix
         {
            //var product = products[i - 1];     
            var product = products[i];                   // <- fix

            if (predicate(product))
            {
               //return --i  
               return i;                                 // <- fix
            }
         }
         return -1;
      }
   }
}
