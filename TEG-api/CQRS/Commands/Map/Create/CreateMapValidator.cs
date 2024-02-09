using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;

namespace TEG_api.CQRS.Commands.Map.Create
{
    public class CreateMapValidator : AbstractValidator<CreateMapCommand>
    {

        private readonly TEGContext _db;

        public CreateMapValidator(TEGContext db)
        {
            RuleFor(x => x.CreateMapRequest.Description).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorCreateMap.DESCRIPTION_EMPTY.ToString());
            RuleFor(x => x.CreateMapRequest.IsActive).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorCreateMap.ACTIVE_EMPTY.ToString());
            RuleFor(x => x).MustAsync(CheckMap).WithMessage(ErrorsEnumResponse.ErrorCreateUser.ALREADY_EXISTS.ToString());
            _db = db;
        }

        private async Task<bool> CheckMap(CreateMapCommand command, CancellationToken Token)
        {
            bool CheckMap = await _db.Maps.AnyAsync(p => p.Description == command.CreateMapRequest.Description);
            return !CheckMap;
        }
    }
}
