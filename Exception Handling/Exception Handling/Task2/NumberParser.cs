using System;
using static System.Net.Mime.MediaTypeNames;

namespace Task2
{
   public class NumberParser : INumberParser
   {
      public int Parse(string stringValue)
      {
         int result = 0;
         const int ZeroASCII = 48;
         const int NineASCII = 57;

         if (stringValue == null)
         {
            throw new ArgumentNullException(nameof(stringValue));
         }

         var trimmedStringValue = stringValue.Trim();

         if (trimmedStringValue.Length == 0)
         {
            throw new FormatException(nameof(stringValue));
         }

         var sign = GetSign(trimmedStringValue, out int initialIndex);

         for (int i = initialIndex; i < trimmedStringValue.Length; i++)
         {
            if (trimmedStringValue[i] >= ZeroASCII && trimmedStringValue[i] <= NineASCII)
            {
               int digit = trimmedStringValue[i] - ZeroASCII;

               if ((int.MaxValue - digit) / 10 < result && sign > 0)
               {
                  throw new OverflowException();
               }

               if ((int.MinValue + digit) / 10 > result * sign && sign < 0)
               {
                  throw new OverflowException();
               }

               result = result * 10 + digit;
            }
            else
            {
               throw new FormatException(nameof(stringValue));
            }
         }

         return result * sign;
      }

      private int GetSign(string value, out int initialIndex)
      {
         short sign = 1;
         initialIndex = 0;

         if (value[0] == '-')
         {
            sign = -1;
            initialIndex++;
         }
         else if (value[0] == '+')
         {
            initialIndex++;
         }

         return sign;
      }

   }
}