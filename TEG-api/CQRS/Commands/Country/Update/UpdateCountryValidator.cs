using FluentValidation;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Commands.Country.Update
{
    public class UpdateCountryValidator : AbstractValidator<UpdateCountryCommand>
    {
        private readonly TEGContext _db;
        private readonly ICRUDService _c;

        public UpdateCountryValidator(TEGContext db, ICRUDService c)
        {
            RuleFor(x => x.UpdateCountryRequest.Id).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateCountry.ID_EMPTY.ToString());
            RuleFor(x => x.UpdateCountryRequest.Name).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateCountry.NAME_EMPTY.ToString());
            RuleFor(x => x.UpdateCountryRequest.Troops).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateCountry.TROOPS_EMPTY.ToString());
            RuleFor(x => x.UpdateCountryRequest.ContinentId).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateCountry.CONTINENT_ID_EMPTY.ToString());
            RuleFor(x => x).MustAsync(CheckExitsCountry).WithMessage(ErrorsEnumResponse.ErrorUpdateCountry.COUNTRY_NOT_EXISTS.ToString());
            _c = c;
            _db = db;
        }

        private async Task<bool> CheckExitsCountry(UpdateCountryCommand command, CancellationToken token)
        {
            return await _c.CheckExists<Common.Models.Country>(command.UpdateCountryRequest.Id.ToString());
        }
    }
}
