using ReversePolishNotationKata;
using Xunit;

namespace ReversePolishNotationKata.Tests
{
   public class ReversePolishNotationCalculatorTests
   {
      [Theory]
      [InlineData("3 4 +", 7.0)]
      [InlineData("1 2 +", 3.0)]
      [InlineData("5 3 +", 8.0)]
      [InlineData("10 3 +", 13.0)]
      public void Calculate_AddOperation_ShouldReturnTwoNumbersSum(string input, double expectedResult)
      {
         // Arrange

         // Act
         var actualResult = ReversePolishNotationCalculator.Calculate(input);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData("3 4 -", -1.0)]
      [InlineData("1 2 -", -1.0)]
      [InlineData("5 3 -", 2.0)]
      [InlineData("10 3 -", 7.0)]
      public void Calculate_SubtractionOperation_ShouldReturnTwoNumbersDifference(string input, double expectedResult)
      {
         // Arrange

         // Act
         var actualResult = ReversePolishNotationCalculator.Calculate(input);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData("3 4 *", 12.0)]
      [InlineData("1 2 *", 2.0)]
      [InlineData("5 3 *", 15.0)]
      [InlineData("10 3 *", 30.0)]
      public void Calculate_MultiplicationOperation_ShouldReturnTwoNumbersProduct(string input, double expectedResult)
      {
         // Arrange

         // Act
         var actualResult = ReversePolishNotationCalculator.Calculate(input);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData("3 3 /", 1.0)]
      [InlineData("1 2 /", 0.5)]
      [InlineData("6 3 /", 2.0)]
      [InlineData("30 3 /", 10.0)]
      public void Calculate_DivisionOperation_ShouldReturnTwoNumbersQuotient(string input, double expectedResult)
      {
         // Arrange

         // Act
         var actualResult = ReversePolishNotationCalculator.Calculate(input);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData("3 4 + 2 +", 9.0)]
      [InlineData("1 2 + 0 +", 3.0)]
      [InlineData("5 3 + 2 +", 10.0)]
      [InlineData("10 3 + 7 +", 20.0)]
      [InlineData("10 3 + 7 + 10 +", 30.0)]
      [InlineData("1 2 + 3 + 4 + 5 +", 15.0)]
      public void Calculate_MultipleAdditionOperations_ShouldReturnSum(string input, double expectedResult)
      {
         // Arrange

         // Act
         var actualResult = ReversePolishNotationCalculator.Calculate(input);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData("3 4 - 1 -", -2.0)]
      [InlineData("1 2 - 5 - 5 -", -11.0)]
      [InlineData("5 3 - 1 - 1 - 0 -", 0.0)]
      public void Calculate_MultipleSubtractionOperations_ShouldReturnDifference(string input, double expectedResult)
      {
         // Arrange

         // Act
         var actualResult = ReversePolishNotationCalculator.Calculate(input);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData("3 4 * 1 *", 12.0)]
      [InlineData("1 1 * 5 * 5 *", 25.0)]
      [InlineData("5 3 * 1 * 1 * 0 *", 0.0)]
      public void Calculate_MultipleMultiplicationOperations_ShouldReturnProduct(string input, double expectedResult)
      {
         // Arrange

         // Act
         var actualResult = ReversePolishNotationCalculator.Calculate(input);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData("8 4 / 2 /", 1.0)]
      [InlineData("100 5 / 5 / 2 /", 2.0)]
      [InlineData("1000 10 / 10 / 1 / 1 /", 10.0)]
      public void Calculate_MultipleDivisionOperations_ShouldReturnQuotient(string input, double expectedResult)
      {
         // Arrange

         // Act
         var actualResult = ReversePolishNotationCalculator.Calculate(input);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData("3 4 + 4 -", 3.0)]
      [InlineData("1 2 + 2 - 2 -", -1.0)]
      [InlineData("5 3 - 3 + 5 +", 10.0)]
      [InlineData("10 3 + 7 + 5 - 5 -", 10.0)]
      public void Calculate_MultipleAdditionAndSubtractionOperations_ShouldReturnResult(string input, double expectedResult)
      {
         // Arrange

         // Act
         var actualResult = ReversePolishNotationCalculator.Calculate(input);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData("3 4 + 5 6 + *", 77.0)]
      [InlineData("3 4 - 5 *", -5.0)]
      [InlineData("3 4 + 7 /", 1.0)]
      [InlineData("1 4 + 2 /", 2.5)]
      public void Calculate_MultipleDifferentOperations_ShouldReturnResult(string input, double expectedResult)
      {
         // Arrange

         // Act
         var actualResult = ReversePolishNotationCalculator.Calculate(input);

         // Assert
         Assert.Equal(expectedResult, actualResult);
      }

      [Theory]
      [InlineData("3 0 /", typeof(DivideByZeroException))]
      [InlineData("3 4 + 0 /", typeof(DivideByZeroException))]
      [InlineData("100 5 / 5 / 0 /", typeof(DivideByZeroException))]
      public void Calculate_DivisionByZero_ShouldThrowDivideByZeroException(string input, Type expectedExceptionType)
      {
         // Arrange
         
         // Act and Assert
         Assert.Throws(expectedExceptionType, () => ReversePolishNotationCalculator.Calculate(input));
      }

      [Theory]
      [InlineData("3 1 / /", typeof(InvalidOperationException))]
      [InlineData("3 4 + - * 1 / +", typeof(InvalidOperationException))]
      [InlineData("100 5 / / 5 / / 1 / +", typeof(InvalidOperationException))]
      public void Calculate_IncorrectNumberOfOperators_ShouldThrowInvalidOperationException(string input, Type expectedExceptionType)
      {
         // Arrange

         // Act and Assert
         Assert.Throws(expectedExceptionType, () => ReversePolishNotationCalculator.Calculate(input));
      }

      [Theory]
      [InlineData("3 a / ", typeof(FormatException))]
      [InlineData("a 4 + b /", typeof(FormatException))]
      [InlineData("100 a / b / c +", typeof(FormatException))]
      public void Calculate_IncorrectOperands_ShouldThrowFormatException(string input, Type expectedExceptionType)
      {
         // Arrange

         // Act and Assert
         Assert.Throws(expectedExceptionType, () => ReversePolishNotationCalculator.Calculate(input));
      }

      [Theory]
      [InlineData("", typeof(ArgumentException))]
      [InlineData(" ", typeof(ArgumentException))]
      [InlineData(null, typeof(ArgumentException))]
      public void Calculate_NullOrEmptyInput_ShouldThrowArgumentException(string input, Type expectedExceptionType)
      {
         // Arrange

         // Act and Assert
         Assert.Throws(expectedExceptionType, () => ReversePolishNotationCalculator.Calculate(input));
      }

      [Theory]
      [InlineData("3 1 1 / 1 2 ", typeof(InvalidOperationException))]
      [InlineData("3 4 + 1 2 3 + ", typeof(InvalidOperationException))]
      [InlineData("100 5 / 5 / 1 / 1 1 1 ", typeof(InvalidOperationException))]
      public void Calculate_IncorrectNumberOfOperands_ShouldThrowInvalidOperationException(string input, Type expectedExceptionType)
      {
         // Arrange

         // Act and Assert
         Assert.Throws(expectedExceptionType, () => ReversePolishNotationCalculator.Calculate(input));
      }

   }


}
