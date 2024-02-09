using MediatR;

namespace TEG_api.CQRS.Querys.Countrys.All
{
    public class GetAllCountrysQuery : IRequest<ListCountrys>
    {
    }
}
