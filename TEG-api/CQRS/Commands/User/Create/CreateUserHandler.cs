using MediatR;
using TEG_api.Data;
using TEG_api.Services.Interface;
using AutoMapper;

namespace TEG_api.CQRS.Commands.User.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly TEGContext _db;
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public CreateUserHandler(TEGContext db, ICRUDService crudService, IMapper mapper)
        {
            _db = db;
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _crudService.CheckValidator(request);

            var newUser = _mapper.Map<Common.Models.User>(request.CreateUserRequest);

            await _crudService.PostAsyncNotDuplicate(newUser);

            return true;
        }
    }
}
