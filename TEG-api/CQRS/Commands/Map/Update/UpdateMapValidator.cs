using FluentValidation;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Commands.Map.Update
{
    public class UpdateMapValidator : AbstractValidator<UpdateMapCommand>
    {
        private readonly TEGContext _db;
        private readonly ICRUDService _c;

        public UpdateMapValidator(TEGContext db, ICRUDService c)
        {
            RuleFor(x => x.UpdateMapRequest.Description).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateMap.DESCRIPTION_EMPTY.ToString());
            RuleFor(x => x.UpdateMapRequest.IsActive).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorUpdateMap.ACTIVE_EMPTY.ToString());
            RuleFor(x => x).MustAsync(CheckExitsMap).WithMessage(ErrorsEnumResponse.ErrorUpdateMap.MAP_NOT_EXISTS.ToString());
            _c = c;
            _db = db;
        }

        private async Task<bool> CheckExitsMap(UpdateMapCommand command, CancellationToken token)
        {
            return await _c.CheckExists<Common.Models.Map>(command.UpdateMapRequest.Id.ToString());
        }
    }
}
