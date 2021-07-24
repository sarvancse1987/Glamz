﻿using Glamz.Domain.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Glamz.Business.System.Interfaces.Admin
{
    public interface IAdminSiteMapService
    {
        Task<IList<AdminSiteMap>> GetSiteMap();
    }
}
