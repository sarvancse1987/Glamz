using MediatR;
using System.Collections.Generic;

namespace Glamz.Api.Commands.Models.Common
{
    public class GenerateTokenCommand : IRequest<string>
    {
        public Dictionary<string, string> Claims { get; set; }
    }
}
