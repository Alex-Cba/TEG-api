using AutoMapper;
using MediatR;
using TEG_api.Common.DTOs;
using TEG_api.Common.Models;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Querys.All.AllCountries
{
    public class ListCountries
    {
        public List<CountryDTO> lstCountries { get; set; }
    }
    public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesQuery, ListCountries>
    {
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;
        public GetAllCountriesHandler(ICRUDService crudService, IMapper mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<ListCountries> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            ListCountries listCountries = new ListCountries();

            var countryDB = await _crudService.GetAsync<Country>();

            listCountries.lstCountries = _mapper.Map<List<CountryDTO>>(countryDB);

            return listCountries;
        }
    }
}
