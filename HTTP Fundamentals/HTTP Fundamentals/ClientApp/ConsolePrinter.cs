namespace ClientApp
{
   public static class ConsolePrinter
   {
      public static void PrintOutput(string? output)
      {
         if (String.IsNullOrEmpty(output)) 
            return;

         Console.WriteLine(output);
      }

      public static void PrintStatus(int status)
      {
         Console.WriteLine(status);
      }
   }
}
