using MediatR;

namespace TEG_api.CQRS.Querys.All.AllUsers
{
    public class GetAllUsersQuery : IRequest<ListUsers>
    {
    }
}
