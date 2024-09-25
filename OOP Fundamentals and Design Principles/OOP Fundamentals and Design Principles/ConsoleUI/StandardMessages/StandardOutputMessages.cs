namespace ConsoleUI
{
   public static class StandardOutputMessages
   {
      public static void OutputNothingFound()
      {
         Console.WriteLine($"No documents were found!");
         Console.ReadLine();
      }
      public static void OutputNothingFoundByDocumentNumber(string? documentNumber)
      {
         Console.WriteLine($"No documents with document number {documentNumber} were found!");
         Console.ReadLine();
      }

      public static void OutputNoDocumentNumberEntered()
      {
         Console.WriteLine("No document number was entered!");
         Console.ReadLine();
      }

      public static void OutputErrorMessage(string message)
      {
         Console.WriteLine($"An error occurred: {message}");
         Console.ReadLine();
      }
   }
}
