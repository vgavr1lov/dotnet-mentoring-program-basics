using EFHomeTaskLibrary;
using DapperHomeTaskLibrary;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsoleApp2
{
   public class Program
   {
      static void Main(string[] args)
      {
         using IHost host = Host.CreateDefaultBuilder(args)
              .ConfigureLogging(logging =>
                        { logging.ClearProviders(); })
              .ConfigureServices(ConfigureServices)
              .Build();

         using (var scope = host.Services.CreateScope())
         {
            var service = scope.ServiceProvider.GetRequiredService<Application>();
            service.Run();
         }
      }

      static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
      {
         services.AddEFHomeTaskLibrary("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFHomeTaskDb;Integrated Security=True;Connect Timeout=30;Encrypt=False");
         services.AddSingleton<Application>();
      }
   }
}
