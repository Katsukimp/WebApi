using FluentValidation;
using WebApiAspNetCore.Domain.Entities;

namespace WebApiAspNetCore.Domain.Validator
{
    public class ProductImageValidator : AbstractValidator<ProductImage>
    {
        public ProductImageValidator()
        {
            RuleFor(x => x.Filename)
                .NotEmpty()
                .NotNull()
                    .WithMessage("A imagem do produto não pode ter o nome nulo nem vazio.");

            RuleFor(x => x.Size)
                .InclusiveBetween(0, 1000000 * 5)
                    .WithMessage("A imagem deve ter menos que 5Mb.");
        }
    }
}
