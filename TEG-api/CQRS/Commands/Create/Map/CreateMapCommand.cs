using MediatR;
using TEG_api.Common.Request;

namespace TEG_api.CQRS.Commands.Create.Map
{
    public record CreateMapCommand(CreateMapRequest CreateMapRequest) : IRequest<bool>;
}
