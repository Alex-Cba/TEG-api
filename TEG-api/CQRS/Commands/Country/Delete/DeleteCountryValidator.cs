using FluentValidation;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;

namespace TEG_api.CQRS.Commands.Country.Delete
{
    public class DeleteCountryValidator : AbstractValidator<DeleteCountryCommand>
    {
        private readonly TEGContext _db;

        public DeleteCountryValidator(TEGContext db)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorDeleteEntities.ID_EMPTY.ToString());
            _db = db;
        }
    }
}
