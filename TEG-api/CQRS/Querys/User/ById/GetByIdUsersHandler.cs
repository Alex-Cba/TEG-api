using AutoMapper;
using MediatR;
using TEG_api.Common.DTOs;
using TEG_api.CQRS.Querys.User.All;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Querys.User.ById
{
    public class GetByIdUsersHandler : IRequestHandler<GetByIdUsersQuery, UserDTO>
    {
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public GetByIdUsersHandler(ICRUDService crudService, IMapper mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetByIdUsersQuery request, CancellationToken cancellationToken)
        {

            var userDB = await _crudService.GetByIdAsync<Common.Models.User>(request.Id);

            var response = _mapper.Map<UserDTO>(userDB);

            return response;
        }
    }
}
