using MediatR;
using TEG_api.Data;
using TEG_api.Services.Interface;
using AutoMapper;

namespace TEG_api.CQRS.Commands.Map.SoftDelete
{
    public class SoftDeleteMapHandler : IRequestHandler<SoftDeleteMapCommand, bool>
    {
        private readonly TEGContext _db;
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public SoftDeleteMapHandler(TEGContext db, ICRUDService crudService, IMapper mapper)
        {
            _db = db;
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(SoftDeleteMapCommand request, CancellationToken cancellationToken)
        {
            await _crudService.CheckValidator(request);

            await _crudService.SoftDeleteAsync(new Common.Models.Map() { Id = request.Id });

            return true;
        }
    }
}
