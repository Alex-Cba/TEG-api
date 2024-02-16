using AutoMapper;
using MediatR;
using TEG_api.Common.DTOs;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Querys.Continents.ById
{
    public class GetByIdContinentsHandler : IRequestHandler<GetByIdContinentsQuery, ContinentDTO>
    {
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public GetByIdContinentsHandler(ICRUDService crudService, IMapper mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<ContinentDTO> Handle(GetByIdContinentsQuery request, CancellationToken cancellationToken)
        {

            var continentDB = await _crudService.GetByIdAsync<Common.Models.Continent>(request.Id);

            var response = _mapper.Map<ContinentDTO>(continentDB);

            return response;
        }
    }
}
