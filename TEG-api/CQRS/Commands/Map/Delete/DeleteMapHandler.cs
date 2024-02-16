using MediatR;
using TEG_api.Data;
using TEG_api.Services.Interface;
using AutoMapper;

namespace TEG_api.CQRS.Commands.Map.Delete
{
    public class DeleteMapHandler : IRequestHandler<DeleteMapCommand, bool>
    {
        private readonly TEGContext _db;
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public DeleteMapHandler(TEGContext db, ICRUDService crudService, IMapper mapper)
        {
            _db = db;
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteMapCommand request, CancellationToken cancellationToken)
        {
            await _crudService.CheckValidator(request);

            await _crudService.DeleteAsync<Common.Models.Map>(request.Id.ToString());

            return true;
        }
    }
}
