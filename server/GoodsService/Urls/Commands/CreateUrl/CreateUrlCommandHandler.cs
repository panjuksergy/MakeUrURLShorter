using MediatR;
using SparkSwim.GoodsService.Goods.Models;
using SparkSwim.GoodsService.Interfaces;
using SparkSwim.GoodsService.ShortenerService;

namespace SparkSwim.GoodsService.Goods.Commands.CreateGood;

public class CreateUrlCommandHandler : IRequestHandler<CreateUrlCommand, string>
{
    private readonly IUrlDbContext _dbContext;
    private readonly IShortener _shortener;

    public CreateUrlCommandHandler(IUrlDbContext dbContext, IShortener shortener)
    {
        _dbContext = dbContext;
        _shortener = shortener;
    }

    public async Task<string> Handle(CreateUrlCommand request, CancellationToken cancellationToken)
    {
        var newUrl = new Url
        {
            UrlId = Guid.NewGuid(),
            UrlFrom = request.UrlFrom,
            UrlTo = _shortener.GenerateShortUrlHash(),
            UserId = request.UserId
        };

        await _dbContext.Urls.AddAsync(newUrl, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return newUrl.UrlTo;
    }
}