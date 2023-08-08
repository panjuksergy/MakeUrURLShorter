using AutoMapper;
using SparkSwim.Core.Mapping;
using SparkSwim.GoodsService.Goods.Commands.CreateGood;

namespace SparkSwim.GoodsService.Goods.Models;

public class CreateUrlDto : IMapWith<CreateUrlCommand>
{
    public Guid UserId { get; set; }
    public string UrlFrom { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateUrlDto, CreateUrlCommand>();
    }
}