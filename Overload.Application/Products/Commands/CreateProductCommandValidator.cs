using FluentValidation;

namespace Overload.Pim.Application.Products.Commands
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
