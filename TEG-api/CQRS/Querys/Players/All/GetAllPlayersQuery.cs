using MediatR;

namespace TEG_api.CQRS.Querys.Players.All
{
    public class GetAllPlayersQuery : IRequest<ListPlayers>
    {
    }
}
