using AutoMapper;
using MediatR;
using TEG_api.Common.DTOs;
using TEG_api.Common.Models;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Querys.Countrys.All
{
    public class ListCountrys
    {
        public List<CountryDTO> lstCountrys { get; set; }
    }
    public class GetAllCountrysHandler : IRequestHandler<GetAllCountrysQuery, ListCountrys>
    {
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public GetAllCountrysHandler(ICRUDService crudService, IMapper mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<ListCountrys> Handle(GetAllCountrysQuery request, CancellationToken cancellationToken)
        {
            ListCountrys listCountrys = new ListCountrys();

            var CountryDB = await _crudService.GetAsync<Country>();

            listCountrys.lstCountrys = _mapper.Map<List<CountryDTO>>(CountryDB);

            return listCountrys;
        }
    }
}
