using Xunit;

namespace HarryPotterKata.Tests
{
   public class BookTests
   {
      [Theory]
      [InlineData(1, 8.0)]
      [InlineData(2, 8.0)]
      [InlineData(3, 8.0)]
      [InlineData(4, 8.0)]
      [InlineData(5, 8.0)]
      public void Book_Input_1_To_5_ShouldReturnPrice(int bookNumber, double expectedResult)
      {
         // Arrange
         var book = new Book(bookNumber);

         // Act 
         var actualResult = book.BookPrice;

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData(101, typeof(ArgumentOutOfRangeException))]
      [InlineData(0, typeof(ArgumentOutOfRangeException))]
      public void Book_InputBookNumberOutOfRange_ShouldThrowArgumentOutOfRangeException(int bookNumber, Type expectedExceptionType)
      {
         // Arrange

         // Act and Assert
         Assert.Throws(expectedExceptionType, () => new Book(bookNumber));
      }

   }
}

