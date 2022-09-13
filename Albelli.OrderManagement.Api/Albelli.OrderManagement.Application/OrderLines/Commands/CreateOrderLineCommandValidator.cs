using FluentValidation;

namespace Albelli.OrderManagement.Application.OrderLines.Commands
{
    public class CreateOrderLineCommandValidator : AbstractValidator<CreateOrderLineCommand>
    {
        public CreateOrderLineCommandValidator()
        {
            RuleFor(createOrderLineCommand => createOrderLineCommand.ProductType).NotNull().NotEmpty();
            RuleFor(createOrderLineCommand => createOrderLineCommand.Quantity).GreaterThan(0);
        }
    }
}
