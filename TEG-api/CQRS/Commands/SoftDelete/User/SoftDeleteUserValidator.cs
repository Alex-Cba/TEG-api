using FluentValidation;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;

namespace TEG_api.CQRS.Commands.SoftDelete.User

{
   public class SoftDeleteUserValidator : AbstractValidator<SoftDeleteUserCommand>
   {
       private readonly TEGContext _db;

       public SoftDeleteUserValidator(TEGContext db)
       {
            RuleFor(x => x.Id).NotEmpty().WithMessage(ErrorsEnumResponse.ErrorDeleteEntities.NOT_FOUND.ToString());
            _db = db;
       }
   }
}
