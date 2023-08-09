using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Interfaces;
using SparkSwim.GoodsService.Products.Queries.GetProduct;

namespace SparkSwim.GoodsService.Products.Queries.GetProductList;

public class GetUrlListQueryHandler : IRequestHandler<GetUrlListQuery, UrlListVm>
{
    private readonly IUrlDbContext _urlDbContext;
    private readonly IMapper _mapper;

    public GetUrlListQueryHandler(IUrlDbContext dbContext, IMapper mapper)
    {
        _urlDbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<UrlListVm> Handle(GetUrlListQuery request, CancellationToken cancellationToken)
    {
        /// If request filters is null, it will be ignored on filtering
        
        var products = await _urlDbContext.Urls
            // .Skip(request.NumberFromToSkip)
            // .Take(request.CountToGet)
            .ProjectTo<UrlLookUpDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new UrlListVm { Urls = products };
    }
}