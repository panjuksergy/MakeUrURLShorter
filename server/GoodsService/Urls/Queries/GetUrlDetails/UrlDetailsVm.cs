using AutoMapper;
using SparkSwim.Core.Mapping;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Products.Queries.GetProduct;

public class UrlDetailsVm : IMapWith<Url>
{
    public Guid UrlId { get; set; }
    public Guid UserId { get; set; }
    public string UrlFrom { get; set; }
    public string UrlTo { get; set; }
    public DateTime CreationDate { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Url, UrlDetailsVm>();
    }
}