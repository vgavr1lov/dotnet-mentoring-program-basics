using Xunit;

namespace StringSumKata.Test
{
   public class StringSumTests
   {
      [Theory]
      [InlineData("", "1", "0")]
      [InlineData("1", "", "0")]
      public void Sum_InputEmptyString_ShouldRecieveZero(string num1, string num2, string expectedResult)
      {
         // Arrange

         // Act 
         var actualResult = StringSum.Sum(num1, num2);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData("-1", "1", "0")]
      [InlineData("1", "-1", "0")]
      [InlineData("-1", "-1", "0")]

      public void Sum_InputNegativeNumber_ShouldRecieveZero(string num1, string num2, string expectedResult)
      {
         // Arrange

         // Act 
         var actualResult = StringSum.Sum(num1, num2);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData("1.2", "1", "0")]
      [InlineData("1", "1.1", "0")]
      [InlineData("1.1", "1.2", "0")]

      public void Sum_InputFractionNumber_ShouldRecieveZero(string num1, string num2, string expectedResult)
      {
         // Arrange

         // Act 
         var actualResult = StringSum.Sum(num1, num2);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData("1", "2", "3")]
      [InlineData("1", "1", "2")]
      [InlineData("2", "3", "5")]
      [InlineData("100", "1000", "1100")]

      public void Sum_InputNaturalNumbers_ShouldRecieveSum(string num1, string num2, string expectedResult)
      {
         // Arrange

         // Act 
         var actualResult = StringSum.Sum(num1, num2);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData("abc", "2", "0")]
      [InlineData("1", "?/", "0")]
      [InlineData("Gdf", "dcc", "0")]
      [InlineData(" ", "BBB", "0")]

      public void Sum_InputNotNumbers_ShouldRecieveZero(string num1, string num2, string expectedResult)
      {
         // Arrange

         // Act 
         var actualResult = StringSum.Sum(num1, num2);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData("2147483647", "1", "2147483648")]
      [InlineData("100000000000000", "100000000000000", "200000000000000")]

      public void Sum_InputVeryLargeNumbers_ShouldRecieveZero(string num1, string num2, string expectedResult)
      {
         // Arrange

         // Act 
         var actualResult = StringSum.Sum(num1, num2);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }
   }
}
