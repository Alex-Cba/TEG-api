using MediatR;
using TEG_api.Common.Response;

namespace TEG_api.CQRS.Commands.Delete.User 
{
    public record DeleteUserCommand(Guid Id) : IRequest<DeleteUserResponse> ;
}
