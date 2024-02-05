using MediatR;

namespace TEG_api.CQRS.Querys.Match.All
{
    public class GetAllMatchesQuery : IRequest<ListMatches>
    {
    }
}
