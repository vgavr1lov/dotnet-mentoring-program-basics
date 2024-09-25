namespace FizzBuzzKata
{
   public static class FizzBuzz
   {
      public static string GetFizzBuzzResult(int input)
      {
         if (input <= 0 || input > 100)
            throw new ArgumentOutOfRangeException();

         if (input % 3 == 0 && input % 5 == 0)
            return "FizzBuzz";

         if (input % 3 == 0)
            return "Fizz";

         if (input % 5 == 0)
            return "Buzz";

         return input.ToString();
      }
   }
}
