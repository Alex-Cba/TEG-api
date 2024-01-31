using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;

namespace TEG_api.CQRS.Commands.Create.User
{
   public class CreateUserValidator : AbstractValidator<CreateUserCommand> 
    {

       private readonly TEGContext _db;

       public CreateUserValidator(TEGContext db) {
            RuleFor(x => x.CreateUserRequest.Name).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorCreateUser.NAME_EMPTY.ToString());
            RuleFor(x => x.CreateUserRequest.Email).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorCreateUser.EMAIL_EMPTY.ToString());
            RuleFor(x => x.CreateUserRequest.Phone).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorCreateUser.PHONE_EMPTY.ToString());
            RuleFor(x => x.CreateUserRequest.Password).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorCreateUser.PASSWORD_EMPTY.ToString());
            RuleFor(x => x).MustAsync(CheckUser).WithMessage(ErrorsEnumResponse.ErrorCreateUser.ALREADY_EXISTS.ToString());
            _db = db;
       }

        private async Task<bool> CheckUser(CreateUserCommand command, CancellationToken Token)
        {
            bool CheckUser = await _db.Users.AnyAsync(p => p.Email == command.CreateUserRequest.Email);
            return !CheckUser;
        }
    }
}
