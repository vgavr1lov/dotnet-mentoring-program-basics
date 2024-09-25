using Xunit;
using HarryPotterKata;

namespace HarryPotterKata.Tests
{
   public class HarryPotterBookshopTests
   {
      [Theory]
      [InlineData(new int[] { 1 }, 8.0)]
      public void CalculateBaketCost_InputOneBook_ShouldCalculateCostForSingleBook(int[] books, double expectedResult)
      {
         // Arrange
         var harryPotterBookshop = new HarryPotterBookshop();
         var basket = books.Select(x => new Book(x)).ToArray();

         // Act 
         var actualResult = harryPotterBookshop.CalculateBaketCost(basket);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData(new int[] { 1, 2, 3 }, 21.6)]
      [InlineData(new int[] { 5, 2, 4 }, 21.6)]
      [InlineData(new int[] { 1, 3, 5 }, 21.6)]
      [InlineData(new int[] { 4, 3, 2 }, 21.6)]
      public void CalculateBaketCost_Input_3_DifferentBooks_ShouldCalculateCostForBooks(int[] books, double expectedResult)
      {
         // Arrange
         var harryPotterBookshop = new HarryPotterBookshop();
         var basket = books.Select(x => new Book(x)).ToArray();

         // Act 
         var actualResult = harryPotterBookshop.CalculateBaketCost(basket);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData(new int[] { 1, 2, 2 }, 23.2)]
      [InlineData(new int[] { 5, 5, 4 }, 23.2)]
      [InlineData(new int[] { 3, 3, 5 }, 23.2)]
      [InlineData(new int[] { 4, 3, 4 }, 23.2)]
      public void CalculateBaketCost_Input_2_DifferentBooks_ShouldCalculateCostForBooks(int[] books, double expectedResult)
      {
         // Arrange
         var harryPotterBookshop = new HarryPotterBookshop();
         var basket = books.Select(x => new Book(x)).ToArray();

         // Act 
         var actualResult = harryPotterBookshop.CalculateBaketCost(basket);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData(new int[] { 1, 2, 3, 4 }, 25.6)]
      [InlineData(new int[] { 5, 2, 4, 1 }, 25.6)]
      [InlineData(new int[] { 1, 3, 5, 2 }, 25.6)]
      [InlineData(new int[] { 4, 3, 2, 1 }, 25.6)]
      public void CalculateBaketCost_Input_4_DifferentBooks_ShouldCalculateCostForBooks(int[] books, double expectedResult)
      {
         // Arrange
         var harryPotterBookshop = new HarryPotterBookshop();
         var basket = books.Select(x => new Book(x)).ToArray();

         // Act 
         var actualResult = harryPotterBookshop.CalculateBaketCost(basket);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData(new int[] { 1, 2, 3, 4, 5 }, 30)]
      [InlineData(new int[] { 5, 2, 4, 1, 3 }, 30)]
      [InlineData(new int[] { 1, 3, 5, 2, 4 }, 30)]
      [InlineData(new int[] { 4, 3, 2, 1, 5 }, 30)]
      public void CalculateBaketCost_Input_5_DifferentBooks_ShouldCalculateCostForBooks(int[] books, double expectedResult)
      {
         // Arrange
         var harryPotterBookshop = new HarryPotterBookshop();
         var basket = books.Select(x => new Book(x)).ToArray();

         // Act 
         var actualResult = harryPotterBookshop.CalculateBaketCost(basket);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData(new int[] { 1, 1, 2, 2, 3, 3, 4, 5 }, 51.60)]
      [InlineData(new int[] { 5, 4, 3, 2, 1, 3, 4, 5 }, 51.60)]
      public void CalculateBaketCost_Input_5_DifferentBooks_And_3_DifferentBooks_ShouldCalculateCostForBooks(int[] books, double expectedResult)
      {
         // Arrange
         var harryPotterBookshop = new HarryPotterBookshop();
         var basket = books.Select(x => new Book(x)).ToArray();

         // Act 
         var actualResult = harryPotterBookshop.CalculateBaketCost(basket);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData(new int[] { }, 0.00)]
      public void CalculateBaketCost_InputNoBooks_ShouldCalculateZeroCost(int[] books, double expectedResult)
      {
         // Arrange
         var harryPotterBookshop = new HarryPotterBookshop();
         var basket = books.Select(x => new Book(x)).ToArray();

         // Act 
         var actualResult = harryPotterBookshop.CalculateBaketCost(basket);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }
   }
}
