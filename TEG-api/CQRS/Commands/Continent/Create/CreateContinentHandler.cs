using MediatR;
using TEG_api.Data;
using TEG_api.Services.Interface;
using AutoMapper;

namespace TEG_api.CQRS.Commands.Continent.Create
{
    public class CreateContinentHandler : IRequestHandler<CreateContinentCommand, bool>
    {
        private readonly TEGContext _db;
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public CreateContinentHandler(TEGContext db, ICRUDService crudService, IMapper mapper)
        {
            _db = db;
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateContinentCommand request, CancellationToken cancellationToken)
        {
            await _crudService.CheckValidator(request);

            var newContinent = _mapper.Map<Common.Models.Continent>(request.CreateContinentRequest);

            await _crudService.PostAsyncNotDuplicate(newContinent);

            return true;
        }
    }
}
