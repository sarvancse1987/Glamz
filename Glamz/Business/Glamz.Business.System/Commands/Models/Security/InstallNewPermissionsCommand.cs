using Glamz.Business.Common.Interfaces.Security;
using MediatR;

namespace Glamz.Business.System.Commands.Models.Security
{
    public class InstallNewPermissionsCommand : IRequest<bool>
    {
        public IPermissionProvider PermissionProvider { get; set; }
    }
}
