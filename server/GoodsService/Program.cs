using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SparkSwim.Core.Mapping;
using SparkSwim.GoodsService;
using SparkSwim.GoodsService.Interfaces;
using SparkSwim.Core.Identity;
using SparkSwim.GoodsService.ShortenerService;

var builder = WebApplication.CreateBuilder(args);
RegisterServices(builder.Services);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<UrlDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
    }
}

Configure(app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddControllers();

    services.AddSingleton<IShortener, DefaultShortener>();
    services.AddDbContext<IUrlDbContext, UrlDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    
    services.AddAutoMapper(config =>
    {
        config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
        config.AddProfile(new AssemblyMappingProfile(typeof(IUrlDbContext).Assembly));
    });
    services.AddApplication();
    services.AddControllers();

    services.AddJwtAuth(builder.Configuration);
}

void Configure(IApplicationBuilder app)
{
    // app.UseHttpsRedirection();
    app.UseRouting();
    app.UseCors(_ => { _.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();});
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
}