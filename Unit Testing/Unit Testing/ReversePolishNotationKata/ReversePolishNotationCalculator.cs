namespace ReversePolishNotationKata
{
   public static class ReversePolishNotationCalculator
   {
      private static readonly string[] operations = { "+", "-", "*", "/" };
      public static double Calculate(string input)
      {
         if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Input cannot be empty!");

         Stack<double> operands = new();

         var parsedInput = input.Trim().Split(" ");
         foreach (var item in parsedInput)
         {
            var operation = (operations.Contains(item))
               ? item
               : null;
            if (operation != null)
            {
               if (operands.Count < 2)
                  throw new InvalidOperationException("Incorrect number of operators!");
               operands.Push(PerformOperation(operation, operands.Pop(), operands.Pop()));
            }
            else
            {
               if (!double.TryParse(item, out double itemParsed))
                  throw new FormatException($"Incorrect operand {item}!");
               operands.Push(itemParsed);
            }
         }

         if (operands.Count > 1)
            throw new InvalidOperationException("Incorrect number of operands!");

         return operands.Pop();
      }

      private static double PerformOperation(string operation, double num2, double num1)
      {
         switch (operation)
         {
            case "+":
               return num1 + num2;
            case "-":
               return num1 - num2;
            case "*":
               return num1 * num2;
            case "/":
               if (num2 == 0)
                  throw new DivideByZeroException();
               return num1 / num2;
         }

         return 0.0;
      }
   }
}
