using Albelli.OrderManagement.Application.Interfaces;
using Albelli.OrderManagement.Domain;
using System.Collections.Generic;

namespace Albelli.OrderManagement.Application
{
    public class PackageWidthCalculator : IPackageWidthCalculator
    {
        // TODO: Unit test
        public double Calculate(List<OrderLine> orderLines)
        {
            double packageWidth = 0;

            foreach (var orderLine in orderLines)
            {
                if (orderLine.Quantity <= orderLine.ProductInfo.FitInColumn)
                {
                    packageWidth += orderLine.ProductInfo.WidthMm;
                }
                else
                {
                    int remainder = orderLine.Quantity % orderLine.ProductInfo.FitInColumn;
                    int allocatedPlaces = (int)(orderLine.Quantity / orderLine.ProductInfo.FitInColumn);

                    packageWidth += remainder == 0
                        ? allocatedPlaces * orderLine.ProductInfo.WidthMm
                        : (allocatedPlaces + 1) * orderLine.ProductInfo.WidthMm;
                }
            }

            return packageWidth;
        }
    }
}
