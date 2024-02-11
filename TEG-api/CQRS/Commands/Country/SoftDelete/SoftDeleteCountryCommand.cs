using MediatR;

namespace TEG_api.CQRS.Commands.Country.SoftDelete
{
    public record SoftDeleteCountryCommand(int Id) : IRequest<bool>;
}
