using Glamz.Api.Commands.Models.Common;
using Glamz.Api.Infrastructure.Extensions;
using Glamz.Api.Jwt;
using Glamz.Infrastructure.Configuration;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Commands.Handlers.Common
{
    public class GenerateTokenWebCommandHandler : IRequestHandler<GenerateTokenWebCommand, string>
    {
        private readonly GrandWebApiConfig _grandWebApiConfig;

        public GenerateTokenWebCommandHandler(GrandWebApiConfig grandWebApiConfig)
        {
            _grandWebApiConfig = grandWebApiConfig;
        }

        public async Task<string> Handle(GenerateTokenWebCommand request, CancellationToken cancellationToken)
        {
            var token = new JwtTokenBuilder();
            token.AddSecurityKey(JwtSecurityKey.Create(_grandWebApiConfig.SecretKey));

            if (_grandWebApiConfig.ValidateIssuer)
                token.AddIssuer(_grandWebApiConfig.ValidIssuer);
            if (_grandWebApiConfig.ValidateAudience)
                token.AddAudience(_grandWebApiConfig.ValidAudience);

            token.AddClaims(request.Claims);
            token.AddExpiry(_grandWebApiConfig.ExpiryInMinutes);
            token.Build();

            return await Task.FromResult(token.Build().Value);
        }
    }
}
