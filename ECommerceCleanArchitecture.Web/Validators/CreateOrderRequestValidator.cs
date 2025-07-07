using ECommerceCleanArchitecture.Web.DTOs;
using FluentValidation;
namespace ECommerceCleanArchitecture.Web.Validators
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be a valid user.");

            RuleFor(x => x.PaymentMethodId)
                .GreaterThan(0).WithMessage("PaymentMethodId must be valid.");

            RuleFor(x => x.Items)
                .NotNull().WithMessage("Items list cannot be null.")
                .NotEmpty().WithMessage("Order must contain at least one item.");

            RuleForEach(x => x.Items)
                .SetValidator(new CreateOrderItemRequestValidator());
        }
    }
}
