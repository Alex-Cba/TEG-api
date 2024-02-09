using MediatR;
using TEG_api.Data;
using TEG_api.Services.Interface;
using AutoMapper;

namespace TEG_api.CQRS.Commands.Country.Create
{
    public class CreateCountryHandler : IRequestHandler<CreateCountryCommand, bool>
    {
        private readonly TEGContext _db;
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public CreateCountryHandler(TEGContext db, ICRUDService crudService, IMapper mapper)
        {
            _db = db;
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            await _crudService.CheckValidator(request);

            var newCountry = _mapper.Map<Common.Models.Country>(request.CreateCountryRequest);

            await _crudService.PostAsyncNotDuplicate(newCountry);

            return true;
        }
    }
}
