using MediatR;
using TEG_api.Common.Request;
using TEG_api.Common.Response;

namespace TEG_api.CQRS.Commands.Update.User 
{
    public record UpdateUserCommand(UpdateUserRequest UpdateUserRequest) : IRequest<UpdateUserResponse>;
}
