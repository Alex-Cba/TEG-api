using AutoMapper;
using MediatR;
using TEG_api.Common.DTOs;
using TEG_api.Common.Models;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Querys.Continents.All
{
    public class ListContinents
    {
        public List<ContinentDTO> lstContinent { get; set; }
    }
    public class GetAllContinentsHandler : IRequestHandler<GetAllContinentsQuery, ListContinents>
    {
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public GetAllContinentsHandler(ICRUDService crudService, IMapper mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<ListContinents> Handle(GetAllContinentsQuery request, CancellationToken cancellationToken)
        {
            ListContinents listContinents = new ListContinents();

            var ContinentDB = await _crudService.GetAsync<Continent>();

            listContinents.lstContinent = _mapper.Map<List<ContinentDTO>>(ContinentDB);

            return listContinents;
        }
    }
}
