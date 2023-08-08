using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SparkSwim.GoodsService.Exceptions;
using SparkSwim.GoodsService.Interfaces;

namespace SparkSwim.GoodsService.Products.Commands.DeleteProduct
{
    public class DeleteUrlCommandHandler : IRequestHandler<DeleteUrlCommand>
    {
        private readonly IUrlDbContext _dbContext;

        public DeleteUrlCommandHandler(IUrlDbContext urlDbContext)
        {
            _dbContext = urlDbContext;
        }

        public async Task Handle(DeleteUrlCommand request, CancellationToken cancellationToken)
        {
            var urlToDelete = await _dbContext.Urls.FindAsync(request.UrlId);

            if (urlToDelete == null)
            {
                throw new NotFoundException(nameof(UrlDbContext), request.UrlId);
            }

            _dbContext.Urls.Remove(urlToDelete);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}