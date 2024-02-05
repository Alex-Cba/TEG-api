using MediatR;
using TEG_api.Common.Request;

namespace TEG_api.CQRS.Commands.User.Create
{
    public record CreateUserCommand(CreateUserRequest CreateUserRequest) : IRequest<bool>;
}
