using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Interfaces;
using SparkSwim.GoodsService.Products.Queries.GetProduct;

namespace SparkSwim.GoodsService.Products.Queries.GetProductList;

public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, ProductListVm>
{
    private readonly IUrlDbContext _urlDbContext;
    private readonly IMapper _mapper;

    public GetProductListQueryHandler(IUrlDbContext dbContext, IMapper mapper)
    {
        _urlDbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ProductListVm> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        /// If request filters is null, it will be ignored on filtering
        
        var products = await _urlDbContext.Urls
            // .Skip(request.NumberFromToSkip)
            // .Take(request.CountToGet)
            .ProjectTo<UrlLookUpDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new ProductListVm { Urls = products };
    }
}