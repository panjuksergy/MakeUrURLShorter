using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparkSwim.GoodsService.Products.Queries.GetProduct;
using SparkSwim.GoodsService.Products.Queries.GetProductList;

namespace SparkSwim.GoodsService.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UrlController : BaseController
{
    [HttpGet("getAllProducts")]
    public async Task<ActionResult<ProductListVm>> GetAllProducts([FromBody] GetProductListQuery request)
    {
        var query = new GetProductListQuery
        {
            // NumberFromToSkip = request.NumberFromToSkip,
            // CountToGet = request.CountToGet,
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpGet("getUrl/{Id}")]
    public async Task<ActionResult<UrlVm>> GetUrlWithoutDetailsById(Guid Id)
    {
        var query = new GetUrlQuery
        {
            UrlId = Id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

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
}