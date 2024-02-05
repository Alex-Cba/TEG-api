using AutoMapper;
using MediatR;
using TEG_api.Common.DTOs;
using TEG_api.Common.Models;
using TEG_api.CQRS.Querys.All.AllUsers;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Querys.Configuration.All
{
    public class ListConfigurations
    {
        public List<ConfigurationDTO> lstConfigurations { get; set; }
    }
    public class GetAllConfigurationsHandler : IRequestHandler<GetAllConfigurationsQuery, ListConfigurations>
    {
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public GetAllConfigurationsHandler(ICRUDService crudService, IMapper mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }
        public async Task<ListConfigurations> Handle(GetAllConfigurationsQuery request, CancellationToken cancellationToken)
        {
            ListConfigurations listConfigurations = new ListConfigurations();

            var configurationDB = await _crudService.GetAsync<Configuration>();

            listConfigurations.lstConfigurations = _mapper.Map<List<ConfigurationDTO>>(configurationDB);

            return listConfigurations;
        }
    }
}
