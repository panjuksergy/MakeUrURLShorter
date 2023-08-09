using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.GoodsService.Controllers;
using SparkSwim.GoodsService.Goods.Commands.CreateGood;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Products.Commands.DeleteProduct;
using SparkSwim.GoodsService.Products.Queries.GetProduct;

namespace SparkSwim.GoodsService.Controllers;
    
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UrlAuthorizeController : BaseController
{
    private readonly IMapper _mapper;
    public UrlAuthorizeController(IMapper mapper) => _mapper = mapper;

    #region Urls
    [HttpGet("details/{Id}")]
    public async Task<ActionResult<UrlDetailsVm>> GetProductDetails(Guid Id)
    {
        var query = new GetUrlDetailsQuery
        {
            UrlId = Id,
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);  
    }
    
    [HttpPost("createUrl")]
    public async Task<ActionResult<CreateUrlCommand>> CreateProduct([FromBody] CreateUrlDto createUrlDto)
    {
        createUrlDto.UserId = UserId;
        var command = _mapper.Map<CreateUrlCommand>(createUrlDto);
        var urlTo = await Mediator.Send(command);
        return Ok(urlTo);
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