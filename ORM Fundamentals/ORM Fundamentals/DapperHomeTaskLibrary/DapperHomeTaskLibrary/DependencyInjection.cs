using Data;
using Microsoft.Extensions.DependencyInjection;

namespace DapperHomeTaskLibrary;

public static class DependencyInjection
{
   public static IServiceCollection AddDapperHomeTaskLibrary(this IServiceCollection services, string connectionString)
   {
      services.AddScoped<IDbConnectionFactory>(_ => new DbConnectionFactory(connectionString));
      services.AddScoped<IProductRepository, ProductRepository>();
      services.AddScoped<IOrderRepository, OrderRepository>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      return services;
   }
}

