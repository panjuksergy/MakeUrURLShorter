using AutoMapper;
using SparkSwim.Core.Mapping;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Products.Queries.GetProductList;

public class UrlLookUpDto : IMapWith<Url>
{
    public Guid UrlId { get; set; }
    public string UrlFrom { get; set; }
    public string UrlTo { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Url, UrlLookUpDto>();
    }
}