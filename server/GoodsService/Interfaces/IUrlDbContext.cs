using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Interfaces;

public interface IUrlDbContext
{
    DbSet<Url> Urls { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}