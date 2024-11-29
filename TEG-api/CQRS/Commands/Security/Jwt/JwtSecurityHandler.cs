using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TEG_api.Data;
using TEG_api.Helpers.JwtSecurity;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Commands.Security.Jwt
{
    public class JwtSecurityHandler : IRequestHandler<JwtSecurityCommand, string>
    {
        private readonly TEGContext _db;
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;
        private readonly JwtHelper _jwtHelper;


        //TODO: remove
        private readonly string LoginName = "admin";
        private readonly string LoginPassword = "admin";

        public JwtSecurityHandler(TEGContext db, ICRUDService crudService, IMapper mapper, JwtHelper jwtHelper)
        {
            _db = db;
            _crudService = crudService;
            _mapper = mapper;
            _jwtHelper = jwtHelper;
        }

        public async Task<string> Handle(JwtSecurityCommand request, CancellationToken cancellationToken)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Name.Equals(request.login.LoginName) && u.Password.Equals(request.login.LoginPassword));

            if (request.login.LoginName.Equals(LoginName) && request.login.LoginPassword.Equals(LoginPassword))
            {
                var response = _jwtHelper.GenerateToken("1", request.login.LoginName, request.login.LoginPassword);
                return response;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
