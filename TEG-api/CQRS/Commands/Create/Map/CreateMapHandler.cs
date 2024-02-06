using AutoMapper;
using MediatR;
using TEG_api.Data;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Commands.Create.Map
{
    public class CreateMapHandler : IRequestHandler<CreateMapCommand, bool>
    {
        private readonly TEGContext _db;
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public CreateMapHandler(TEGContext db, ICRUDService crudService, IMapper mapper)
        {
            _db = db;
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateMapCommand request, CancellationToken cancellationToken)
        {
            await _crudService.CheckValidator(request);

            var newMap = _mapper.Map<Common.Models.Map>(request.CreateMapRequest);

            await _crudService.PostAsyncNotDuplicate(newMap);

            return true;
        }
    }
}
