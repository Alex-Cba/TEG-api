using MediatR;
using TEG_api.Controllers;

namespace TEG_api.CQRS.Commands.Security.Jwt
{
    public record JwtSecurityCommand(LoginObsolete login) : IRequest<string>;
}
