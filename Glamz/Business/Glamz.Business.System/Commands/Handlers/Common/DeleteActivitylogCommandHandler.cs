using Glamz.Business.System.Commands.Models.Common;
using Glamz.Domain.Data;
using Glamz.Domain.Logging;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Business.System.Commands.Handlers.Common
{
    public class DeleteActivitylogCommandHandler : IRequestHandler<DeleteActivitylogCommand, bool>
    {
        private readonly IRepository<ActivityLog> _repositoryActivityLog;

        public DeleteActivitylogCommandHandler(IRepository<ActivityLog> repositoryActivityLog)
        {
            _repositoryActivityLog = repositoryActivityLog;
        }

        public async Task<bool> Handle(DeleteActivitylogCommand request, CancellationToken cancellationToken)
        {
            await _repositoryActivityLog.ClearAsync();
            return true;
        }
    }
}
