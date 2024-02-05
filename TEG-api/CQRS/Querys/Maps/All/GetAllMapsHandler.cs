using AutoMapper;
using MediatR;
using TEG_api.Common.DTOs;
using TEG_api.Common.Models;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Querys.Maps.All
{
    public class ListMaps
    {
        public List<MapDTO> lstMaps { get; set; }
    }
    public class GetAllMapsHandler : IRequestHandler<GetAllMapsQuery, ListMaps>
    {
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public GetAllMapsHandler(ICRUDService crudService, IMapper mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<ListMaps> Handle(GetAllMapsQuery request, CancellationToken cancellationToken)
        {
            ListMaps listMaps = new ListMaps();

            var MapDB = await _crudService.GetAsync<Map>();

            listMaps.lstMaps = _mapper.Map<List<MapDTO>>(MapDB);

            return listMaps;
        }
    }
}
