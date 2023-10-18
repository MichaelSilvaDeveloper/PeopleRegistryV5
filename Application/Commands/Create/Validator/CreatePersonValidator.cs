using Application.Commands.Create.Requests;
using FluentValidation;

namespace Application.Commands.Create.Validator
{
    public class CreatePersonValidator : AbstractValidator<CreatePersonRequest>
    {
        public CreatePersonValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Nome é requerido");
            RuleFor(x => x.Email).NotNull().WithMessage("Email é requerido");
        }
    }
}   