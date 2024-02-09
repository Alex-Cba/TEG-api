using AutoMapper;
using MediatR;
using TEG_api.Common.DTOs;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Querys.Countrys.ById
{
    public class GetByIdCountrysHandler : IRequestHandler<GetByIdCountrysQuery, CountryDTO>
    {
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public GetByIdCountrysHandler(ICRUDService crudService, IMapper mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<CountryDTO> Handle(GetByIdCountrysQuery request, CancellationToken cancellationToken)
        {

            var CountryDB = await _crudService.GetByIdAsync<Common.Models.Country>(request.Id);

            var response = _mapper.Map<CountryDTO>(CountryDB);

            return response;
        }
    }
}
