using System.Net;

namespace ListenerApp
{
   public class HTTPListner
   {
      private const string MyName = "Valentin";
      public void ListenToURI(string prefix)
      {
         HttpListener listener = new HttpListener();
         listener.Prefixes.Add(prefix);
         listener.Start();
         Console.WriteLine("Listening...");

         while (true)
         {
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            ProcessEndpoint(request, response);

            if (response.StatusCode == 404)
               break;
         }

         listener.Stop();
      }

      private void ConstructResponse(HttpListenerResponse response, string responseString)
      {
         byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
         response.ContentLength64 = buffer.Length;
         System.IO.Stream output = response.OutputStream;
         output.Write(buffer, 0, buffer.Length);
         output.Close();
      }

      private void GetMyName(HttpListenerResponse response)
      {
         response.StatusCode = 200;
         ConstructResponse(response, MyName);
      }

      private void GetResponseInformation(HttpListenerResponse response)
      {
         response.StatusCode = 100;
         response.OutputStream.Close();
      }

      private void GetResponseSuccess(HttpListenerResponse response)
      {
         response.StatusCode = 200;
         ConstructResponse(response, "Success");
      }

      private void GetResponseRedirection(HttpListenerResponse response)
      {
         response.StatusCode = 300;
         ConstructResponse(response, "Redirection");
      }

      private void GetResponseClientError(HttpListenerResponse response)
      {
         response.StatusCode = 400;
         ConstructResponse(response, "Client error");
      }

      private void GetResponseServerError(HttpListenerResponse response)
      {
         response.StatusCode = 500;
         ConstructResponse(response, "Server error");
      }

      private void GetMyNameByHeader(HttpListenerResponse response)
      {
         response.StatusCode = 200;
         response.AddHeader("X-MyName", MyName);
         ConstructResponse(response, string.Empty);
      }

      private void GetMyNameByCookies(HttpListenerResponse response)
      {
         response.StatusCode = 200;
         var cookie = new Cookie("MyName", MyName);
         response.Cookies.Add(cookie);
         ConstructResponse(response, string.Empty);
      }

      private void ProcessEndpoint(HttpListenerRequest request, HttpListenerResponse response)
      {
         switch (request.Url?.PathAndQuery)
         {
            case "/MyName/":
               GetMyName(response);
               break;
            case "/Information/":
               GetResponseInformation(response);
               break;
            case "/Success/":
               GetResponseSuccess(response);
               break;
            case "/Redirection/":
               GetResponseRedirection(response);
               break;
            case "/ClientError/":
               GetResponseClientError(response);
               break;
            case "/ServerError/":
               GetResponseServerError(response);
               break;
            case "/MyNameByHeader/":
               GetMyNameByHeader(response);
               break;
            case "/MyNameByCookies/":
               GetMyNameByCookies(response);
               break;
            case "/":
               response.StatusCode = 200;
               ConstructResponse(response, "Resource found");
               break;
            default:
               response.StatusCode = 404;
               ConstructResponse(response, "Resource not found");
               break;
         }
      }
   }
}
