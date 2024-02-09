using MediatR;
using TEG_api.Data;
using TEG_api.Services.Interface;
using AutoMapper;
using TEG_api.Common.Response;

namespace TEG_api.CQRS.Commands.Map.Update
{
    public class UpdateMapHandler : IRequestHandler<UpdateMapCommand, UpdateMapResponse>
    {
        private readonly TEGContext _db;
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public UpdateMapHandler(TEGContext db, ICRUDService crudService, IMapper mapper)
        {
            _db = db;
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<UpdateMapResponse> Handle(UpdateMapCommand request, CancellationToken cancellationToken)
        {
            await _crudService.CheckValidator(request);

            var mapUpdated = await _crudService.PutAsync(_mapper.Map<Common.Models.Map>(request.UpdateMapRequest));

            var response = _mapper.Map<UpdateMapResponse>(mapUpdated);

            return response;
        }
    }
}
