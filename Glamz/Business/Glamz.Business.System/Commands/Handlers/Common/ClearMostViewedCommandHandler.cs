using Glamz.Business.System.Commands.Models.Common;
using Glamz.Domain.Catalog;
using Glamz.Domain.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Business.System.Commands.Handlers.Common
{
    public class ClearMostViewedCommandHandler : IRequestHandler<ClearMostViewedCommand, bool>
    {
        private readonly IRepository<Product> _repositoryProduct;

        public ClearMostViewedCommandHandler(IRepository<Product> repositoryProduct)
        {
            _repositoryProduct = repositoryProduct;
        }

        public async Task<bool> Handle(ClearMostViewedCommand request, CancellationToken cancellationToken)
        {
            await _repositoryProduct.UpdateManyAsync(x => x.Viewed != 0,
                        UpdateBuilder<Product>.Create().Set(x => x.Viewed, 0));

            return true;
        }
    }
}
