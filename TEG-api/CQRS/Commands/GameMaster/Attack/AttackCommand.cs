using MediatR;
using TEG_api.Common.Request;
using TEG_api.Common.Response;

namespace TEG_api.CQRS.Commands.GameMaster.Attack
{
    public record AttackCommand(AttackRequest AttackRequest) : IRequest<AttackResponse>;
}
