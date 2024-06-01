using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.Model
{
    public class OrderDetailsView
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? OrderStatus { get; set; }
        public string? DeliveryType { get; set; }
        public decimal? OrderTotalPrice { get; set; }
        public string? DeliveryLocation { get; set; }
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? TotalQty { get; set; }
        public int? OrderDetailId { get; set; }
        public int? ProductId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitQty { get; set; }
        public decimal? OrderDetailTotalPrice { get; set; }
    }
}
