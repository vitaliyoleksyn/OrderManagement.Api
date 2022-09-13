namespace Albelli.OrderManagement.Domain
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public int Quantity { get; set; }


        public int OrderId { get; set; }
        public ProductInfo ProductInfo { get; set; }
    }
}
