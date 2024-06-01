using ECMSApi.Service.BussinessLayer.Interface;
using ECMSApi.Service.Model;
using Microsoft.AspNetCore.Mvc;

namespace ECMSApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrder _order;
        public OrderController(IOrder order)
        {
				_order = order;
        }
        [HttpPost]
		public int Post(Order entity)
		{
			_order.Post(entity);
			return entity.Id;
		}
		[HttpGet]
		[Route("GetOrderDeatilsList")]
		public List<OrderDetailsView> GetOrderDeatilsList()
		{
			var list = _order.GetAllOrderDetailsList().ToList();
			return list;	
		}

    }
}
