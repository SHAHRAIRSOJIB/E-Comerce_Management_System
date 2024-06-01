using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.Model
{
	public class Order
	{
		public int Id { get; set; }
		public DateTime? OrderDate { get; set; }
		public string? OrderStatus { get; set; }
		public string? DeliveryType { get; set; }
		public decimal? TotalPrice { get; set; }
		public string? DeliveryLoaction { get; set; }
		public string? CustomerName { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public int? TotalQty { get; set; }
		public virtual ICollection<OrderDetails>? OrderDetails { get; set; } = new List<OrderDetails>();
	}
}
