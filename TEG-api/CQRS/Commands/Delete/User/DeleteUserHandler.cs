using MediatR;
using TEG_api.Data;
using TEG_api.Services.Interface;
using AutoMapper;
using TEG_api.Common.Response;
using Microsoft.EntityFrameworkCore;

namespace TEG_api.CQRS.Commands.Delete.User
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
    {
        private readonly TEGContext _db;
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public DeleteUserHandler(TEGContext db, ICRUDService crudService, IMapper mapper)
        {
            _db = db;
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _crudService.CheckValidator(request);

            var userToDelete = await _db.Users.FirstOrDefaultAsync(u => u.Id == request.Id);

            await _crudService.DeleteAsync(userToDelete);

            return new DeleteUserResponse()
            {
                Name = userToDelete.Name,
            };
        }
    }
}
