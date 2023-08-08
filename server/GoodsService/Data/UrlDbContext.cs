using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Goods.EntityTypeConfiguration;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService;

public class UrlDbContext : DbContext, IUrlDbContext
{
    public DbSet<Url> Urls { get; set; }
    
    public UrlDbContext(DbContextOptions<UrlDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfiguration(new UrlConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}