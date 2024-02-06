using FluentValidation;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;

namespace TEG_api.CQRS.Commands.Create.Country
{
    public class CreateCountryValidator : AbstractValidator<CreateCountryCommand>
    {
        private readonly TEGContext _db;

        public CreateCountryValidator(TEGContext db)
        {
            RuleFor(x => x.CreateCountryRequest.Troops)
                .NotEmpty().WithMessage(ErrorsEnumResponse.ErrorCreateUser.NAME_EMPTY.ToString());
            RuleFor(x => x.CreateCountryRequest.Name)
                .NotEmpty().WithMessage(ErrorsEnumResponse.ErrorCreateUser.NAME_EMPTY.ToString());
            _db = db;
        }
    }
}
