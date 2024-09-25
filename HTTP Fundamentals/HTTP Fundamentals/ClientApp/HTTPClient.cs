namespace ClientApp
{
   public class HTTPClient
   {
      static readonly HttpClient client = new HttpClient();

      public async Task CallURI(string uri)
      {
         var response = await GetResponse(uri);
         if (response != null)
            ProcessResponse(response);
      }

      private async Task<HttpResponseMessage> GetResponse(string uri)
      {
         return await client.GetAsync(uri);
      }

      private async Task<string> GetResponseBody(HttpResponseMessage response)
      {
         return await response.Content.ReadAsStringAsync();
      }

      private async void ProcessResponse(HttpResponseMessage response)
      {
         ProcessResponseStatus(response);
         await ProcessResponseBody(response);
         ProcessResponseHeader(response);
         ProcessCookies(response);
      }

      private void ProcessResponseStatus(HttpResponseMessage response)
      {
         ConsolePrinter.PrintStatus((int)response.StatusCode);
      }

      private void ProcessResponseHeader(HttpResponseMessage response)
      {
         response.Headers.TryGetValues("X-MyName", out var responseHeader);
         var responseHeaderValue = responseHeader?.FirstOrDefault();
         ConsolePrinter.PrintOutput(responseHeaderValue);
      }

      private async Task ProcessResponseBody(HttpResponseMessage response)
      {
         var responseBody = await GetResponseBody(response);
         ConsolePrinter.PrintOutput(responseBody);
      }
      private void ProcessCookies(HttpResponseMessage response)
      {
         response.Headers.TryGetValues("Set-Cookie", out var cookie);
         var cookieValue = cookie?.FirstOrDefault(c => c.Contains("MyName"))?.Split('=')[1];
         ConsolePrinter.PrintOutput(cookieValue);
      }

   }
}
