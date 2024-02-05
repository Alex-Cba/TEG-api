using MediatR;
using TEG_api.Data;
using TEG_api.Services.Interface;
using AutoMapper;
using TEG_api.Common.Response;
using Microsoft.EntityFrameworkCore;

namespace TEG_api.CQRS.Commands.User.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly TEGContext _db;
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public UpdateUserHandler(TEGContext db, ICRUDService crudService, IMapper mapper)
        {
            _db = db;
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _crudService.CheckValidator(request);

            var userToUpdate = await _db.Users.FirstOrDefaultAsync(u => u.Id == request.UpdateUserRequest.Id);

            _mapper.Map(request.UpdateUserRequest, userToUpdate);

            await _db.SaveChangesAsync();

            var response = _mapper.Map<UpdateUserResponse>(userToUpdate);

            return response;
        }
    }
}
