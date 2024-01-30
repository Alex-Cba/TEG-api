using MediatR;
using TEG_api.Common.Request;

namespace TEG_api.CQRS.Commands.Create.User {
    public record CreateUserCommand(CreateUserRequest CreateUserRequest) : IRequest<bool>;
}
