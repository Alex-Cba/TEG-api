using MediatR;
using TEG_api.Data;
using TEG_api.Services.Interface;
using AutoMapper;
using TEG_api.Common.Response;

namespace TEG_api.CQRS.Commands.GameMaster.Attack
{
    public class AttackHandler : IRequestHandler<AttackCommand, AttackResponse>
    {
        private readonly TEGContext _db;
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;
        private readonly IDiceService _diceService;

        public AttackHandler(TEGContext db, ICRUDService crudService, IMapper mapper, IDiceService diceService)
        {
            _db = db;
            _crudService = crudService;
            _mapper = mapper;
            _diceService = diceService;
        }

        public async Task<AttackResponse> Handle(AttackCommand request, CancellationToken cancellationToken)
        {
            await _crudService.CheckValidator(request);

            //TODO: _diceService.ResolveDiceRoll();


            return null;
        }
    }
}
