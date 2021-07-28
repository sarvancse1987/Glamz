using Glamz.Domain.Common;
using Glamz.Domain.Data;
using Glamz.Infrastructure;
using Glamz.Infrastructure.Caching;
using Glamz.Infrastructure.Caching.Constants;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;

namespace Glamz.Api.Infrastructure
{
    public class DbVersionCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public DbVersionCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(
            HttpContext context,
            ICacheBase cacheBase,

            IRepository<GrandNodeVersion> repository)
        {
            if (context == null || context.Request == null)
            {
                await _next(context);
                return;
            }

            var version = cacheBase.Get(CacheKey.GRAND_NODE_VERSION, () => repository.Table.FirstOrDefault());
            if (version == null)
            {
                await context.Response.WriteAsync($"The database does not exist.");
                return;
            }

            if (!version.DataBaseVersion.Equals(GrandVersion.SupportedDBVersion))
            {
                await context.Response.WriteAsync($"The database version is not supported in this software version. " +
                    $"Supported version: {GrandVersion.SupportedDBVersion} , your version: {version.DataBaseVersion}");
            }
            else
            {
                await _next(context);
            }
        }
    }
}
