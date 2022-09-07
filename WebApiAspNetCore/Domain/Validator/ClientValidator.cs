using FluentValidation;
using WebApiAspNetCore.Domain.Entities;

namespace WebApiAspNetCore.Domain.Validator
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("O campo de nome não pode ser vazio.")
                .NotNull()
                    .WithMessage("O campo de nome não pode ser nulo.")
                .Length(3, 30)
                    .WithMessage("O campo de nome deve conter no mínimo 3 caracteres e no máximo 30 caracteres.");
            
            RuleFor(x => x.Lastname)
                .NotEmpty()
                    .WithMessage("O campo de sobrenome não pode ser vazio.")
                .NotNull()
                    .WithMessage("O campo de sobrenome não pode ser nulo.")
                .Length(3, 30)
                    .WithMessage("O campo de sobrenome deve conter no mínimo 3 caracteres e no máximo 30 caracteres.");
        }
    }
}
