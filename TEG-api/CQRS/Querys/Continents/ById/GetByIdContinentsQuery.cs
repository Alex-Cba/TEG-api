using MediatR;
using TEG_api.Common.DTOs;

namespace TEG_api.CQRS.Querys.Continents.ById
{
    public record GetByIdContinentsQuery(string Id) : IRequest<ContinentDTO>;
}
