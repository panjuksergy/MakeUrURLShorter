namespace SparkSwim.GoodsService;

public class DbInitializer
{
    public static void Initialize(UrlDbContext context)
    {
        context.Database.EnsureCreated();       
    }
}