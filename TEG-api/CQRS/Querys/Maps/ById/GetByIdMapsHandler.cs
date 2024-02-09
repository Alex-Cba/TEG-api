using AutoMapper;
using MediatR;
using TEG_api.Common.DTOs;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Querys.Maps.ById
{
    public class GetByIdMapsHandler : IRequestHandler<GetByIdMapsQuery, MapDTO>
    {
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public GetByIdMapsHandler(ICRUDService crudService, IMapper mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<MapDTO> Handle(GetByIdMapsQuery request, CancellationToken cancellationToken)
        {

            var mapsDB = await _crudService.GetByIdAsync<Common.Models.Map>(request.Id);

            var response = _mapper.Map<MapDTO>(mapsDB);

            return response;
        }
    }
}
