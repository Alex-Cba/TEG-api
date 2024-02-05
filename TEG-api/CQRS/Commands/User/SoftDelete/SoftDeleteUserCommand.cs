using MediatR;

namespace TEG_api.CQRS.Commands.User.SoftDelete
{
    public record SoftDeleteUserCommand(Guid Id) : IRequest<bool>;
}
