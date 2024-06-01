namespace ECMS.Models
{
	public class Products :ImageFile
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public string? ImagePath { get; set; }
		public string? Specification { get; set; }
		public decimal? Price { get; set; }
		public int? Category { get; set; }
		public int? Size { get; set; }
		public int? InventoryLevel { get; set; }
		public int? Qty { get; set; }
		public int? Color { get; set; } 
		

	}
}
