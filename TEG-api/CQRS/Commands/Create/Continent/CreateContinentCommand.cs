using MediatR;
using TEG_api.Common.Request;

namespace TEG_api.CQRS.Commands.Create.Continent
{
    public record CreateContinentCommand(CreateContinentRequest CreateContinentRequest) : IRequest<bool>;

}
