using MediatR;
using TEG_api.Common.DTOs;

namespace TEG_api.CQRS.Querys.User.ById
{
    public record GetByIdUsersQuery(string Id) : IRequest<UserDTO>;
}
