using MediatR;

namespace TEG_api.CQRS.Querys.Continents.All
{
    public class GetAllContinentsQuery : IRequest<ListContinents>
    {
    }
}
