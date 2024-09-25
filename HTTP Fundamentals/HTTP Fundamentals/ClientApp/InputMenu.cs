namespace ClientApp
{
   public static class InputMenu
   {
      public static void DisplayMenu()
      {
         Console.WriteLine("Available URLs:");
         Console.WriteLine("http://localhost:8888/");
         Console.WriteLine("http://localhost:8888/MyName/");
         Console.WriteLine("http://localhost:8888/Information/");
         Console.WriteLine("http://localhost:8888/Success/");
         Console.WriteLine("http://localhost:8888/Redirection/");
         Console.WriteLine("http://localhost:8888/ClientError/");
         Console.WriteLine("http://localhost:8888/ServerError/");
         Console.WriteLine("http://localhost:8888/MyNameByHeader/");
         Console.WriteLine("http://localhost:8888/MyNameByCookies/");
         Console.WriteLine("");
         Console.WriteLine("Enter URL:");
         var inputURL = Console.ReadLine();
         ProcessInputURL(inputURL);
      }

      private static void ProcessInputURL(string? inputURL)
      {
         var client = new HTTPClient();

         if (!String.IsNullOrEmpty(inputURL))
         {
            client.CallURI(inputURL);
            Console.ReadLine();
         }

         Console.Clear();
         DisplayMenu();
      }


   }
}
