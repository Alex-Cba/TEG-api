using MediatR;
using TEG_api.Data;
using TEG_api.Services.Interface;
using AutoMapper;

namespace TEG_api.CQRS.Commands.Continent.SoftDelete
{
    public class SoftDeleteContinentHandler : IRequestHandler<SoftDeleteContinentCommand, bool>
    {
        private readonly TEGContext _db;
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public SoftDeleteContinentHandler(TEGContext db, ICRUDService crudService, IMapper mapper)
        {
            _db = db;
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(SoftDeleteContinentCommand request, CancellationToken cancellationToken)
        {
            await _crudService.CheckValidator(request);

            await _crudService.SoftDeleteAsync(new Common.Models.Continent() { Id = request.Id });

            return true;
        }
    }
}
