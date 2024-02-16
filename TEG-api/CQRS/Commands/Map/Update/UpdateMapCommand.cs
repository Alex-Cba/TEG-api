using MediatR;
using TEG_api.Common.Request;
using TEG_api.Common.Response;

namespace TEG_api.CQRS.Commands.Map.Update
{
    public record UpdateMapCommand(UpdateMapRequest UpdateMapRequest) : IRequest<UpdateMapResponse>;
}
