﻿using Glamz.Domain.Permissions;
using System.Collections.Generic;

namespace Glamz.Business.Common.Interfaces.Security
{
    /// <summary>
    /// Permission provider
    /// </summary>
    public interface IPermissionProvider
    {
        /// <summary>
        /// Get permissions
        /// </summary>
        /// <returns>Permissions</returns>
        IEnumerable<Permission> GetPermissions();

        /// <summary>
        /// Get default permissions
        /// </summary>
        /// <returns>Default permissions</returns>
        IEnumerable<DefaultPermission> GetDefaultPermissions();
    }
}
