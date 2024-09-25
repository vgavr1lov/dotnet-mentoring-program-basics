namespace ListenerApp
{
   public class Program
   {
      static void Main(string[] args)
      {
         var listner = new HTTPListner();
         listner.ListenToURI("http://localhost:8888/");
      }
   }
}
