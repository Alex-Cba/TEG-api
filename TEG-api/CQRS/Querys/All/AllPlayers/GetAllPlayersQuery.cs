using MediatR;

namespace TEG_api.CQRS.Querys.All.AllPlayers
{
    public class GetAllPlayersQuery : IRequest<ListPlayers>
    {
    }
}
