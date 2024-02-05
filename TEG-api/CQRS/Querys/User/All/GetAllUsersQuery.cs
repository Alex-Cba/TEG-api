using MediatR;

namespace TEG_api.CQRS.Querys.User.All
{
    public class GetAllUsersQuery : IRequest<ListUsers>
    {
    }
}
