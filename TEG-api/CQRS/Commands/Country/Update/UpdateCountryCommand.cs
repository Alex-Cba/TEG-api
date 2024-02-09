using MediatR;
using TEG_api.Common.Request;
using TEG_api.Common.Response;

namespace TEG_api.CQRS.Commands.Country.Update
{
    public record UpdateCountryCommand(UpdateCountryRequest UpdateCountryRequest) : IRequest<UpdateCountryResponse>;
}
