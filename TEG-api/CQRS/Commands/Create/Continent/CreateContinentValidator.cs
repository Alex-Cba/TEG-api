using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;

namespace TEG_api.CQRS.Commands.Create.Continent
{
    public class CreateContinentValidator : AbstractValidator<CreateContinentCommand>
    {
        private readonly TEGContext _db;
        public CreateContinentValidator(TEGContext db)
        {
            RuleFor(x => x.CreateContinentRequest.MapId).NotEmpty()
                .WithMessage(ErrorsEnumResponse.GenericErros.GENERIC_EMPTY.ToString());
            RuleFor(x => x.CreateContinentRequest.MapId).MustAsync(CheckMap)
                .WithMessage(ErrorsEnumResponse.GenericErros.GENERIC_NOT_EXISTS.ToString());
            RuleFor(x => x.CreateContinentRequest.ValueOfTroops).GreaterThan(0)
                .WithMessage(ErrorsEnumResponse.GenericErros.GENERIC_MINVALUE.ToString());
            RuleFor(x => x.CreateContinentRequest.Name).NotEmpty()
                .WithMessage(ErrorsEnumResponse.GenericErros.GENERIC_EMPTY.ToString());

            _db = db;
        }


        private async Task<bool> CheckMap(int id, CancellationToken Token)
        {
            bool checkMap = await _db.Maps.AnyAsync(m => m.Id == id);
            return checkMap;
        }
    }
}
