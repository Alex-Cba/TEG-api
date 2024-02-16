using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;

namespace TEG_api.CQRS.Commands.Continent.Create
{
    public class CreateContinentValidator : AbstractValidator<CreateContinentCommand>
    {

        private readonly TEGContext _db;

        public CreateContinentValidator(TEGContext db)
        {
            RuleFor(x => x.CreateContinentRequest.Name).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorCreateContinent.NAME_EMPTY.ToString());
            RuleFor(x => x.CreateContinentRequest.ValueOfTroops).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorCreateContinent.VALUE_TROOPS_EMPTY.ToString());
            RuleFor(x => x.CreateContinentRequest.MapId).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorCreateContinent.MAP_ID_EMPTY.ToString());
            RuleFor(x => x).MustAsync(CheckContinent).WithMessage(ErrorsEnumResponse.ErrorCreateContinent.ALREADY_EXISTS.ToString());
            _db = db;
        }

        private async Task<bool> CheckContinent(CreateContinentCommand command, CancellationToken Token)
        {
            bool CheckContinent = await _db.Continents.AnyAsync(p => p.Name == command.CreateContinentRequest.Name);
            return !CheckContinent;
        }
    }
}
