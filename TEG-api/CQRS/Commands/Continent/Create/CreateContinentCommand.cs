using MediatR;
using TEG_api.Common.Request;

namespace TEG_api.CQRS.Commands.Continent.Create
{
    public record CreateContinentCommand(CreateContinentRequest CreateContinentRequest) : IRequest<bool>;
}
