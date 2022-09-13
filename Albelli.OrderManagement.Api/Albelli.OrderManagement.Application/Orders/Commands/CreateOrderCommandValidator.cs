using Albelli.OrderManagement.Application.OrderLines.Commands;
using FluentValidation;

namespace Albelli.OrderManagement.Application.Orders.Commands
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(createOrderCommand => createOrderCommand.Items).NotNull().NotEmpty();
            RuleForEach(x => x.Items).SetValidator(new CreateOrderLineCommandValidator());
        }
    }
}
