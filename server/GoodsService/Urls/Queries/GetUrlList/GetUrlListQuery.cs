using MediatR;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Products.Queries.GetProductList;

public class GetUrlListQuery : IRequest<UrlListVm>
{
    // public int CountToGet { get; set; }
    // public int NumberFromToSkip { get; set; }
}