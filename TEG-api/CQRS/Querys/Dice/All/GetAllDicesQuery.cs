using MediatR;

namespace TEG_api.CQRS.Querys.Dice.All
{
    public class GetAllDicesQuery : IRequest<ListDices>
    {
    }
}
