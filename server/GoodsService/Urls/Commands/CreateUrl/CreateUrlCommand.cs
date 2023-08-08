using SparkSwim.GoodsService.Goods.Models;

namespace SparkSwim.GoodsService.Goods.Commands.CreateGood;
using MediatR;
public class CreateUrlCommand : IRequest<string>
{
    public Guid UserId { get; set; }
    public string UrlFrom { get; set; }
}