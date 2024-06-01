using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.Model
{
	public class OrderDetails
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public int? ProductId { get; set; }
		public decimal? UnitPrice { get; set; }
		public int? UnitQty { get; set; }
		public decimal? TotalPrice { get; set; }


		public virtual Order? Order { get; set; }
	}
}
