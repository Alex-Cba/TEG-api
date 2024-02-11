using MediatR;

namespace TEG_api.CQRS.Commands.Map.Delete
{
    public record DeleteMapCommand(int Id) : IRequest<bool>;
}
