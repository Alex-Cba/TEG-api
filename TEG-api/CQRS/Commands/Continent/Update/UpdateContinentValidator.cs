using FluentValidation;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Commands.Continent.Update
{
    public class UpdateContinentValidator : AbstractValidator<UpdateContinentCommand>
    {
        private readonly TEGContext _db;
        private readonly ICRUDService _c;

        public UpdateContinentValidator(TEGContext db, ICRUDService c)
        {
            RuleFor(x => x.UpdateContinentRequest.Id).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateContinent.ID_EMPTY.ToString());
            RuleFor(x => x.UpdateContinentRequest.Name).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateContinent.NAME_EMPTY.ToString());
            RuleFor(x => x.UpdateContinentRequest.ValueOfTroops).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateContinent.VALUE_TROOPS_EMPTY.ToString());
            RuleFor(x => x.UpdateContinentRequest.MapId).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateContinent.MAP_ID_EMPTY.ToString());
            RuleFor(x => x).MustAsync(CheckExitsContinent).WithMessage(ErrorsEnumResponse.ErrorUpdateContinent.CONTINENT_NOT_EXISTS.ToString());
            _c = c;
            _db = db;
        }

        private async Task<bool> CheckExitsContinent(UpdateContinentCommand command, CancellationToken token)
        {
            return await _c.CheckExists<Common.Models.Continent>(command.UpdateContinentRequest.Id.ToString());
        }
    }
}
