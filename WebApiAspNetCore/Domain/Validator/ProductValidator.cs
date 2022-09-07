using FluentValidation;
using WebApiAspNetCore.Domain.Entities;

namespace WebApiAspNetCore.Domain.Validator
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                    .WithMessage("O campo de descrição não pode ser vazio.")
                .NotNull()
                    .WithMessage("O campo de descrição não pode ser nulo.")
                .Length(3, 40)
                    .WithMessage("O campo de descrição deve conter no mínimo 3 caracteres e no máximo 40 caracteres.");

            RuleFor(x => x.Quantity)
                .NotNull()
                    .WithMessage("O campo de quantidade não pode ser nulo.")
                .Must(Quantity => Quantity < 0)
                    .WithMessage("O campo de quantidade não pode ser menor que 0.");

            RuleFor(x => x.Price)
                .NotNull()
                    .WithMessage("O campo de preço não pode ser nulo.")
                .Must(Price => Price < 0)
                    .WithMessage("O campo de preço não pode ser menor que 0.");
        }
    }
}
