using FluentValidation;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;

namespace TEG_api.CQRS.Commands.Continent.Delete
{
    public class DeleteContinentValidator : AbstractValidator<DeleteContinentCommand>
    {
        private readonly TEGContext _db;

        public DeleteContinentValidator(TEGContext db)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorDeleteEntities.ID_EMPTY.ToString());
            _db = db;
        }
    }
}
