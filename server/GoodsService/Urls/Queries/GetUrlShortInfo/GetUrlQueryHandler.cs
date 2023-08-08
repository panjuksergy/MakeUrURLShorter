using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SparkSwim.GoodsService.Exceptions;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService.Products.Queries.GetProduct;

public class GetUrlQueryHandler : IRequestHandler<GetUrlQuery, UrlVm>
{
    private readonly IUrlDbContext _urlDbContext;
    private readonly IMapper _mapper;

    public GetUrlQueryHandler(IUrlDbContext dbContext, IMapper mapper)
    {
        _urlDbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<UrlVm> Handle(GetUrlQuery request, CancellationToken cancellationToken)
    {
        var entity =
            await _urlDbContext.Urls.FirstOrDefaultAsync(_ => _.UrlId == request.UrlId,
                cancellationToken);
        
        if (entity == null || entity.UrlId != request.UrlId)
        {
            throw new NotFoundException(nameof(Url), request.UrlId);
        }

        return _mapper.Map<UrlVm>(entity);
    }
}