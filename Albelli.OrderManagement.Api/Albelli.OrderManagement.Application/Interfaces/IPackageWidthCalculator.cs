using Albelli.OrderManagement.Domain;
using System.Collections.Generic;

namespace Albelli.OrderManagement.Application.Interfaces
{
    public interface IPackageWidthCalculator
    {
        double Calculate(List<OrderLine> orderLines);
    }
}
