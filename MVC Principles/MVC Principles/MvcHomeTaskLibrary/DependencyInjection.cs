using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MvcHomeTaskLibrary;

public static class DependencyInjection
{
    public static IServiceCollection AddMvcHomeTaskLibrary(
        this IServiceCollection services,
        string? connectionString,
        int maximumNumberOfProducts)
    {
        services.AddDbContext<NorthwindDbContext>(options =>
            options.UseSqlServer(connectionString)
            .EnableSensitiveDataLogging(false));
        services.AddScoped<CategoryRepository>();
        services.AddScoped<SupplierRepository>();
        services.AddScoped<ProductRepository>(provider =>
        {
            var context = provider.GetRequiredService<NorthwindDbContext>();
            return new ProductRepository(context, maximumNumberOfProducts);
        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}

