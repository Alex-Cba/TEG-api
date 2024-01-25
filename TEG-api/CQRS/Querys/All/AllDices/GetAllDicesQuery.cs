using MediatR;

namespace TEG_api.CQRS.Querys.All.AllDices
{
    public class GetAllDicesQuery : IRequest<ListDices>
    {
    }
}
