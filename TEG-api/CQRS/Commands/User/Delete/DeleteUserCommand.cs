using MediatR;
using TEG_api.Common.Response;

namespace TEG_api.CQRS.Commands.User.Delete
{
    public record DeleteUserCommand(Guid Id) : IRequest<DeleteUserResponse>;
}
