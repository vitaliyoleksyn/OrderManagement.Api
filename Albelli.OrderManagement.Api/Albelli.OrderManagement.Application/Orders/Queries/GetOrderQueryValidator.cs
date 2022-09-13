using FluentValidation;

namespace Albelli.OrderManagement.Application.Orders.Queries
{
    public class GetOrderQueryValidator : AbstractValidator<GetOrderQuery>
    {
        public GetOrderQueryValidator()
        {
            RuleFor(getOrderQuery => getOrderQuery.Id).GreaterThan(-1);
        }
    }
}
