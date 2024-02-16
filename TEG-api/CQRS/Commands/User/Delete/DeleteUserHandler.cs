using MediatR;
using TEG_api.Data;
using TEG_api.Services.Interface;
using AutoMapper;
using TEG_api.Common.Response;
using Microsoft.EntityFrameworkCore;

namespace TEG_api.CQRS.Commands.User.Delete
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
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

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _crudService.CheckValidator(request);

            await _crudService.DeleteAsync<Common.Models.User>(request.Id.ToString());

            return true;
        }
    }
}
