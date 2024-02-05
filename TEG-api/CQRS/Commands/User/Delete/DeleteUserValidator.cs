using FluentValidation;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;

namespace TEG_api.CQRS.Commands.User.Delete
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
        private readonly TEGContext _db;

        public DeleteUserValidator(TEGContext db)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorDeleteEntities.NOT_FOUND.ToString());
            _db = db;
        }
    }
}
