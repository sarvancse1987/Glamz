﻿using Glamz.Business.Common.Extensions;
using Glamz.Business.Common.Interfaces.Localization;
using Glamz.Business.Common.Interfaces.Security;
using Glamz.Business.System.Commands.Models.Security;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Business.System.Commands.Handlers.Security
{
    public class UninstallPermissionsCommandHandler : IRequestHandler<UninstallPermissionsCommand, bool>
    {
        private readonly IPermissionService _permissionService;
        private readonly ITranslationService _translationService;
        private readonly ILanguageService _languageService;

        public UninstallPermissionsCommandHandler(
            IPermissionService permissionService,
            ITranslationService translationService,
            ILanguageService languageService)
        {
            _permissionService = permissionService;
            _translationService = translationService;
            _languageService = languageService;
        }

        public async Task<bool> Handle(UninstallPermissionsCommand request, CancellationToken cancellationToken)
        {
            var permissions = request.PermissionProvider.GetPermissions();
            foreach (var permission in permissions)
            {
                var permission1 = await _permissionService.GetPermissionBySystemName(permission.SystemName);
                if (permission1 != null)
                {
                    await _permissionService.DeletePermission(permission1);

                    //delete permission locales
                    await permission1.DeleteTranslationPermissionName(_translationService, _languageService);
                }
            }
            return true;
        }
    }
}
