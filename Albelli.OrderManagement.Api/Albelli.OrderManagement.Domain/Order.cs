using System.Collections.Generic;

namespace Albelli.OrderManagement.Domain
{
    public class Order
    {
        public int OrderId { get; set; }
        public IEnumerable<OrderLine> Items { get; set; }
        public double MinPackageWidth { get; set; }
    }
}