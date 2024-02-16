using MediatR;

namespace TEG_api.CQRS.Commands.Continent.Delete
{
    public record DeleteContinentCommand(int Id) : IRequest<bool>;
}
