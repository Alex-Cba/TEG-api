using MediatR;

namespace TEG_api.CQRS.Commands.SoftDelete.User 
{
    public record SoftDeleteUserCommand(Guid Id) : IRequest<bool> ;
}
