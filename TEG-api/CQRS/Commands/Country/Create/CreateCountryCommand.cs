using MediatR;
using TEG_api.Common.Request;

namespace TEG_api.CQRS.Commands.Country.Create
{
    public record CreateCountryCommand(CreateCountryRequest CreateCountryRequest) : IRequest<bool>;
}
