using MediatR;
using TEG_api.Common.Request;
using TEG_api.Common.Response;

namespace TEG_api.CQRS.Commands.Continent.Update
{
    public record UpdateContinentCommand(UpdateContinentRequest UpdateContinentRequest) : IRequest<UpdateContinentResponse>;
}
