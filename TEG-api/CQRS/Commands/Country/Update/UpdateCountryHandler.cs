using MediatR;
using TEG_api.Data;
using TEG_api.Services.Interface;
using AutoMapper;
using TEG_api.Common.Response;

namespace TEG_api.CQRS.Commands.Country.Update
{
    public class UpdateCountryHandler : IRequestHandler<UpdateCountryCommand, UpdateCountryResponse>
    {
        private readonly TEGContext _db;
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public UpdateCountryHandler(TEGContext db, ICRUDService crudService, IMapper mapper)
        {
            _db = db;
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<UpdateCountryResponse> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            await _crudService.CheckValidator(request);

            var countryUpdated = await _crudService.PutAsync(_mapper.Map<Common.Models.Country>(request.UpdateCountryRequest));

            var response = _mapper.Map<UpdateCountryResponse>(countryUpdated);

            return response;
        }
    }
}
