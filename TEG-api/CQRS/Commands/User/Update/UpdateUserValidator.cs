using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Commands.User.Update
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly TEGContext _db;
        private readonly ICRUDService _c;

        public UpdateUserValidator(TEGContext db, ICRUDService c)
        {
            RuleFor(x => x.UpdateUserRequest.Name).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateUser.NAME_EMPTY.ToString());
            RuleFor(x => x.UpdateUserRequest.Email).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateUser.EMAIL_EMPTY.ToString());
            RuleFor(x => x.UpdateUserRequest.Phone).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateUser.PHONE_EMPTY.ToString());
            RuleFor(x => x.UpdateUserRequest.IsActive).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateUser.ACTIVE_EMPTY.ToString());
            RuleFor(x => x.UpdateUserRequest.UserType).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateUser.USER_TYPE_EMPTY.ToString());
            RuleFor(x => x).MustAsync(CheckExitsUser).WithMessage(ErrorsEnumResponse.ErrorUpdateUser.USER_NOT_EXISTS.ToString());
            _c = c;
            _db = db;
        }

        private async Task<bool> CheckExitsUser(UpdateUserCommand command, CancellationToken token)
        {
            return await _c.CheckExists<Common.Models.User>(command.UpdateUserRequest.Id.ToString());
        }
    }
}
