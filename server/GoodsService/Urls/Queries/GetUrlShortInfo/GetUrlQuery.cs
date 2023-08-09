using MediatR;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Products.Queries.GetProduct;

public class GetUrlQuery : IRequest<UrlVm>
{
    public string UrlTo { get; set; }
}