using MediatR;

namespace TEG_api.CQRS.Commands.Map.SoftDelete
{
    public record SoftDeleteMapCommand(int Id) : IRequest<bool>;
}
