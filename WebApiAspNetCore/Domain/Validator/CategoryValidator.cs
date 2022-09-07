using FluentValidation;
using WebApiAspNetCore.Domain.Entities;

namespace WebApiAspNetCore.Domain.Validator
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("O campo de nome não pode ser vazio.")
                .NotNull()
                    .WithMessage("O campo de nome não pode ser nulo.")
                .Length(3, 60)
                    .WithMessage("O campo de nome deve conter no mínimo 3 caracteres e no máximo 60 caracteres.");
        }
    }
}
