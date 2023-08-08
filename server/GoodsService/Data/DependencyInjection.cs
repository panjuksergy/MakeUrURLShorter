using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        var conStr = configuration["DbConnection"];
        services.AddDbContext<UrlDbContext>(_ => { _.UseSqlServer(conStr); });
        services.AddScoped<IUrlDbContext>(_ => _.GetService<UrlDbContext>());
        return services;
    }   

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
