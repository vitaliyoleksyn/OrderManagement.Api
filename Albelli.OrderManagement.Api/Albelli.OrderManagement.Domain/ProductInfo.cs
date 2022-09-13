namespace Albelli.OrderManagement.Domain
{
    public class ProductInfo
    {
        public int ProductInfoId { get; set; }
        public string ProductType { get; set; }
        public double WidthMm { get; set; }
        public int FitInColumn { get; set; }
    }
}
