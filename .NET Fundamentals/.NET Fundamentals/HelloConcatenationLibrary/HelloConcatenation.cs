using System;

namespace HelloConcatenationLibrary
{
   public class HelloConcatenation
   {
      public static string ConcatenateTimeAndUsername(string username)
      {
         return $"{DateTime.Now.TimeOfDay} Hello, {username}";
      }
   }
}
