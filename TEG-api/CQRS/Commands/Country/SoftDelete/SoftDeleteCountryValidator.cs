using FluentValidation;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;

namespace TEG_api.CQRS.Commands.Country.SoftDelete

{
    public class SoftDeleteCountryValidator : AbstractValidator<SoftDeleteCountryCommand>
    {
        private readonly TEGContext _db;

        public SoftDeleteCountryValidator(TEGContext db)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorDeleteEntities.ID_EMPTY.ToString());
            _db = db;
        }
    }
}
