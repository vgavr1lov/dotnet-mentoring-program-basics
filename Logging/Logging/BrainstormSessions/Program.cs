using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.EmailPickup;
using Serilog.Sinks.InMemory;

namespace BrainstormSessions
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

         Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

         try
         {
            Log.Information("Starting web application");
            CreateHostBuilder(args).Build().Run();
         }
         catch (Exception ex)
         {
            Log.Fatal(ex, "Application terminated unexpectedly");
         }
         finally
         {
            Log.CloseAndFlush();
         }
      }

      public static IHostBuilder CreateHostBuilder(string[] args)
      {
         return Host.CreateDefaultBuilder(args)
              .UseSerilog()
              .ConfigureWebHostDefaults(webBuilder =>
              {
                 webBuilder.UseStartup<Startup>();
              });
      }
   }
}
