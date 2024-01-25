using FluentValidation;
using StoreAPI.Domain.Entities;

namespace StoreAPI.Domain.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Price).NotNull().NotEmpty().GreaterThan(0);

            RuleFor(product => product.Name).NotNull().NotEmpty()
                                            .MinimumLength(5)
                                            .MaximumLength(30);
        }
    }
}
