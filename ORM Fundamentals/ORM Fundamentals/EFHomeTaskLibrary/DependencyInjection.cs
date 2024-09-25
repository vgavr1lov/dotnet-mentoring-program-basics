using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFHomeTaskLibrary
{
   public static class DependencyInjection
   {
      public static IServiceCollection AddEFHomeTaskLibrary(this IServiceCollection services, string connectionString)
      {
         services.AddDbContext<EFDbContext>(options =>
             options.UseSqlServer(connectionString)
          .EnableSensitiveDataLogging(false));
         services.AddScoped<IProductRepository, ProductRepository>();
         services.AddScoped<IOrderRepository, OrderRepository>();
         services.AddScoped<IUnitOfWork, UnitOfWork>();
         return services;
      }
   }
}
