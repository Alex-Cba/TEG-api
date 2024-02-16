using MediatR;
using TEG_api.Common.DTOs;

namespace TEG_api.CQRS.Querys.Maps.ById
{
    public record GetByIdMapsQuery(string Id) : IRequest<MapDTO>;
}
