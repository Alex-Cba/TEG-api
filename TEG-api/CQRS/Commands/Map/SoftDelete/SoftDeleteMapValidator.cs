using FluentValidation;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;

namespace TEG_api.CQRS.Commands.Map.SoftDelete

{
    public class SoftDeleteMapValidator : AbstractValidator<SoftDeleteMapCommand>
    {
        private readonly TEGContext _db;

        public SoftDeleteMapValidator(TEGContext db)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorDeleteEntities.ID_EMPTY.ToString());
            _db = db;
        }
    }
}
