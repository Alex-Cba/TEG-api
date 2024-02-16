using MediatR;
using TEG_api.Common.DTOs;

namespace TEG_api.CQRS.Querys.Countrys.ById
{
    public record GetByIdCountrysQuery(string Id) : IRequest<CountryDTO>;
}
