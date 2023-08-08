using MediatR;

namespace SparkSwim.GoodsService.Products.Commands.DeleteProduct;

public class DeleteUrlCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid UrlId { get; set; }
}