using MediatR;
using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Products.Queries.GetProduct;

public class GetUrlDetailsQuery : IRequest<UrlDetailsVm>
{
    public Guid UrlId { get; set; }
}