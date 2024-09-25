using FizzBuzzKata;
using Xunit;

namespace FizzBuzzKata.Tests
{
   public class FizzBuzzTests
   {
      [Theory]
      [InlineData(1, "1")]
      [InlineData(2, "2")]
      public void GetFizzBuzzResult_SingleNumber_ReturnsSameNumber(int input, string expectedResult)
      {
         // Arrange
         
         // Act 
         var actualResult = FizzBuzz.GetFizzBuzzResult(input);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData(101, typeof(ArgumentOutOfRangeException))]
      [InlineData(0, typeof(ArgumentOutOfRangeException))]
      public void GetFizzBuzzResult_NumberOutOfRange_ThrowArgumentOutOfRangeException(int input, Type expectedExceptionType)
      {
         // Arrange

         // Act and Assert
         Assert.Throws(expectedExceptionType, () => FizzBuzz.GetFizzBuzzResult(input));
      }

      [Theory]
      [InlineData(3, "Fizz")]
      [InlineData(6, "Fizz")]
      public void GetFizzBuzzResult_NumberDivisibleBy_3_ReturnsFizz(int input, string expectedResult)
      {
         // Arrange
 
         // Act 
         var actualResult = FizzBuzz.GetFizzBuzzResult(input);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData(5, "Buzz")]
      [InlineData(10, "Buzz")]
      public void GetFizzBuzzResult_NumberDivisibleBy_5_ReturnsFizz(int input, string expectedResult)
      {
         // Arrange

         // Act 
         var actualResult = FizzBuzz.GetFizzBuzzResult(input);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData(15, "FizzBuzz")]
      [InlineData(30, "FizzBuzz")]
      public void GetFizzBuzzResult_NumberDivisibleBy_3_And_5_ReturnsFizzBuzz(int input, string expectedResult)
      {
         // Arrange

         // Act 
         var actualResult = FizzBuzz.GetFizzBuzzResult(input);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }
   }
}
