using MediatR;
using TEG_api.Common.DTOs;

namespace TEG_api.CQRS.Querys.All.AllCountries
{
    public class GetAllCountriesQuery : IRequest<ListCountries>
    {
    }
}
