using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECMS.Models
{
	public class CartViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var cart = HttpContext.Session.GetString("Cart");
			var cartItems = string.IsNullOrEmpty(cart) ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(cart);

			return View(cartItems);
		}
	}
}
