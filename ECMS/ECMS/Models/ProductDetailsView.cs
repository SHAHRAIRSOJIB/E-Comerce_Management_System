namespace ECMS.Models
{
    public class ProductDetailsView
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImagePath { get; set; }
        public string ProductSpecification { get; set; }
        public decimal ProductPrice { get; set; }
        public string SizeName { get; set; }
        public string CategoryName { get; set; }
        public string ColorName { get; set; }
        public int InventoryLevel { get; set; }
        public int Quantity { get; set; }
    }
}
