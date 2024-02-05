using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;

namespace TEG_api.CQRS.Commands.User.Update
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly TEGContext _db;

        public UpdateUserValidator(TEGContext db)
        {
            RuleFor(x => x.UpdateUserRequest.Name).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateUser.NAME_EMPTY.ToString());
            RuleFor(x => x.UpdateUserRequest.Email).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateUser.EMAIL_EMPTY.ToString());
            RuleFor(x => x.UpdateUserRequest.Phone).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateUser.PHONE_EMPTY.ToString());
            RuleFor(x => x.UpdateUserRequest.IsActive).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateUser.ACTIVE_EMPTY.ToString());
            RuleFor(x => x.UpdateUserRequest.UserType).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateUser.USER_TYPE_EMPTY.ToString());
            RuleFor(x => x).MustAsync(CheckExitsUser).WithMessage(ErrorsEnumResponse.ErrorUpdateUser.USER_NOT_EXISTS.ToString());
            _db = db;
        }

        private async Task<bool> CheckExitsUser(UpdateUserCommand command, CancellationToken token)
        {
            bool CheckUser = await _db.Users.AnyAsync(p => p.Id == command.UpdateUserRequest.Id);
            return CheckUser;
        }
    }
}
