using System.Numerics;

namespace StringSumKata
{
   public static class StringSum
   {
      private const string Zero = "0";
      private static BigInteger parsedNum1;
      private static BigInteger parsedNum2;
      public static String Sum(string num1, string num2)
      {
         try
         {
            parsedNum1 = BigInteger.Parse(num1);
            parsedNum2 = BigInteger.Parse(num2);
         }
         catch (Exception)
         {
            return Zero;
         }

         if (parsedNum1 <= 0 || parsedNum2 <= 0)
            return Zero;

         return (parsedNum1 + parsedNum2).ToString();
      }
   }
}
