using MediatR;
using TEG_api.Common.Request;

namespace TEG_api.CQRS.Commands.Create.Country
{
    public record CreateCountryCommand(CreateCountryRequest CreateCountryRequest) : IRequest<bool>;
}
