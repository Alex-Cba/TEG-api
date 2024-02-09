using MediatR;
using TEG_api.Common.Request;

namespace TEG_api.CQRS.Commands.Map.Create
{
    public record CreateMapCommand(CreateMapRequest CreateMapRequest) : IRequest<bool>;
}
