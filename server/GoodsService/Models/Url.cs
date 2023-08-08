using SparkSwim.GoodsService.CustomAttributes;

namespace SparkSwim.GoodsService.Goods.Models;

public class Url
{
    public Guid UrlId { get; set; }
    public string UrlFrom { get; set; }
    public string UrlTo { get; set; }
    public DateTime CreationDate { get; set; }
    public Guid UserId { get; set; }
}