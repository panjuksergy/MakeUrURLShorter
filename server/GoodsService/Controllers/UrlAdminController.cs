using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.GoodsService.Controllers;
using SparkSwim.GoodsService.Goods.Commands.CreateGood;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Products.Commands.DeleteProduct;
namespace SparkSwim.GoodsService.Controllers;
    
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UrlAdminController : BaseController
{
    private readonly IMapper _mapper;
    public UrlAdminController(IMapper mapper) => _mapper = mapper;

    #region Urls
    [HttpPost("createUrl")]
    public async Task<ActionResult<CreateUrlCommand>> CreateProduct([FromBody] CreateUrlDto createUrlDto)
    {
        createUrlDto.UserId = UserId;
        var command = _mapper.Map<CreateUrlCommand>(createUrlDto);
        var productId = await Mediator.Send(command);
        return Ok(productId);
    }
    
    [HttpDelete("deleteUrl/{Id}")]
    public async Task<ActionResult<DeleteUrlCommand>> DeleteProduct(Guid Id)
    {
        var command = new DeleteUrlCommand
        {
            UrlId = Id,
        };
        command.UserId = UserId;
        await Mediator.Send(command);
        return Ok();
    }
    #endregion
}