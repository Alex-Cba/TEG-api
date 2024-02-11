using MediatR;

namespace TEG_api.CQRS.Commands.Continent.SoftDelete
{
    public record SoftDeleteContinentCommand(int Id) : IRequest<bool>;
}
