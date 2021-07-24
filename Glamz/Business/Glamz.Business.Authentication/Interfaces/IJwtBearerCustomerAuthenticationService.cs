﻿using Glamz.Domain.Customers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glamz.Business.Authentication.Interfaces
{
    public interface IJwtBearerCustomerAuthenticationService
    {
        Task<bool> Valid(TokenValidatedContext context);
        Task<string> ErrorMessage();
    }
}
