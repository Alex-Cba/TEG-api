using MediatR;

namespace TEG_api.CQRS.Querys.Mission.All
{
    public class GetAllMissionsQuery : IRequest<ListMissions>
    {
    }
}
