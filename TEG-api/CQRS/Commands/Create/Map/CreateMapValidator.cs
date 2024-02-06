using FluentValidation;
using TEG_api.Common.Enums.ErrorsResponse;
using TEG_api.Data;

namespace TEG_api.CQRS.Commands.Create.Map
{
    public class CreateMapValidator : AbstractValidator<CreateMapCommand>
    {

        public CreateMapValidator()
        {
            RuleFor(x => x.CreateMapRequest.Description).NotEmpty()
                .WithMessage(ErrorsEnumResponse.GenericErros.GENERIC_EMPTY.ToString());
        }
    }
}
