using MediatR;

namespace TEG_api.CQRS.Commands.Country.Delete
{
    public record DeleteCountryCommand(int Id) : IRequest<bool>;
}
