namespace ECMS.Models
{
	public class OrderDetails
	{
		public int? ProductId { get; set; }
		public decimal? UnitPrice { get; set; }
		public int? UnitQty { get; set; }
		public decimal? TotalPrice { get; set; }
	}
}
