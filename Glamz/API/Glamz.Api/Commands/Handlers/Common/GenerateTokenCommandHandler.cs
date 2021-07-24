using Glamz.Api.Commands.Models.Common;
using Glamz.Api.Infrastructure.Extensions;
using Glamz.Api.Jwt;
using Glamz.Infrastructure.Configuration;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Glamz.Api.Commands.Handlers.Common
{
    public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, string>
    {
        private readonly ApiConfig _apiConfig;

        public GenerateTokenCommandHandler(ApiConfig apiConfig)
        {
            _apiConfig = apiConfig;
        }
        public async Task<string> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            var token = new JwtTokenBuilder();
            token.AddSecurityKey(JwtSecurityKey.Create(_apiConfig.SecretKey));

            if (_apiConfig.ValidateIssuer)
                token.AddIssuer(_apiConfig.ValidIssuer);
            if (_apiConfig.ValidateAudience)
                token.AddAudience(_apiConfig.ValidAudience);

            token.AddClaims(request.Claims);
            token.AddExpiry(_apiConfig.ExpiryInMinutes);
            token.Build();

            return await Task.FromResult(token.Build().Value);
        }
    }
}
