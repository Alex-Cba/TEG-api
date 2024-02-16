using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;

namespace TEG_api.CQRS.Commands.Country.Create
{
    public class CreateCountryValidator : AbstractValidator<CreateCountryCommand>
    {

        private readonly TEGContext _db;

        public CreateCountryValidator(TEGContext db)
        {
            RuleFor(x => x.CreateCountryRequest.Name).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorCreateCountry.NAME_EMPTY.ToString());
            RuleFor(x => x.CreateCountryRequest.Troops).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorCreateCountry.TROOPS_EMPTY.ToString());
            RuleFor(x => x.CreateCountryRequest.ContinentId).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorCreateCountry.CONTINENT_ID_EMPTY.ToString());
            RuleFor(x => x).MustAsync(CheckCountry).WithMessage(ErrorsEnumResponse.ErrorCreateCountry.ALREADY_EXISTS.ToString());
            _db = db;
        }

        private async Task<bool> CheckCountry(CreateCountryCommand command, CancellationToken Token)
        {
            bool CheckCountry = await _db.Countries.AnyAsync(p => p.Name == command.CreateCountryRequest.Name);
            return !CheckCountry;
        }
    }
}
