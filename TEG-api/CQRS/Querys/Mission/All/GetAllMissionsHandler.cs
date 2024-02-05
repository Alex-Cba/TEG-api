using AutoMapper;
using MediatR;
using TEG_api.Common.DTOs;
using TEG_api.Common.Models;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Querys.Mission.All
{
    public class ListMissions
    {
        public List<MissionDTO>? lstMissions { get; set; }
    }
    public class GetAllMissionsHandler : IRequestHandler<GetAllMissionsQuery, ListMissions>
    {
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public GetAllMissionsHandler(ICRUDService crudService, IMapper mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }
        public async Task<ListMissions> Handle(GetAllMissionsQuery request, CancellationToken cancellationToken)
        {
            ListMissions listMission = new ListMissions();

            var MissionDB = await _crudService.GetAsync<Mission>();

            listMission.lstMissions = _mapper.Map<List<MissionDTO>>(MissionDB);

            return listMission;
        }
    }
}
