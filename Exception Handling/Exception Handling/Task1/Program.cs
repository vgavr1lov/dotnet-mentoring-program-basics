using System;

namespace Task1
{
   internal class Program
   {
      private static void Main(string[] args)
      {
         string inputLine = Console.ReadLine();

         try
         {
            PrintFirstCharacter(inputLine);
         }
         catch (ArgumentNullException ex)
         {
            Console.WriteLine(ex.Message);
         }
         catch (Exception ex)
         {
            Console.WriteLine($"Unknown internal error occured: {ex.Message}"); 
         }


         Console.ReadLine();
      }

      private static void PrintFirstCharacter(string text)
      {
         if (string.IsNullOrEmpty(text))
         {
            throw new ArgumentNullException(nameof(text), $"Incorrect input: text is empty or null");
         }
         Console.WriteLine($"The first character is {text[0]}");

      }
   }
}