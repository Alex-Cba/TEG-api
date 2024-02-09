using MediatR;
using TEG_api.Data;
using TEG_api.Services.Interface;
using AutoMapper;
using TEG_api.Common.Response;

namespace TEG_api.CQRS.Commands.Continent.Update
{
    public class UpdateContinentHandler : IRequestHandler<UpdateContinentCommand, UpdateContinentResponse>
    {
        private readonly TEGContext _db;
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public UpdateContinentHandler(TEGContext db, ICRUDService crudService, IMapper mapper)
        {
            _db = db;
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<UpdateContinentResponse> Handle(UpdateContinentCommand request, CancellationToken cancellationToken)
        {
            await _crudService.CheckValidator(request);

            var continentUpdated = await _crudService.PutAsync(_mapper.Map<Common.Models.Continent>(request.UpdateContinentRequest));

            var response = _mapper.Map<UpdateContinentResponse>(continentUpdated);

            return response;
        }
    }
}
