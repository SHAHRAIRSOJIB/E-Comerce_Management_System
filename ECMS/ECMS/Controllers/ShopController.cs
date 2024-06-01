using ECMS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECMS.Controllers
{
	public class ShopController : Controller
	{
		public IActionResult Home()
		{
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> GetAllProduct(int category)
		{
            List<Products> productList = new List<Products>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrlService.BASE_URL);
                string urlForProduct = client.BaseAddress + "api/Product";
                var responseTask = client.GetAsync(urlForProduct);
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    string apiResponse = await result.Content.ReadAsStringAsync();
                    List<Products> list = JsonConvert.DeserializeObject<List<Products>>(apiResponse);
                    if (category==0)
                    {
						productList = list;
                    }
                    else
                    {
						list = list.Where(x=>x.Category == category).ToList();

					}
                    productList = list;
                }
            }
            return Json(productList);
        }

        [HttpGet]
        public async Task<IActionResult> GetColorNamebyId(int id)
        {
            string colorName = "";
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(BaseUrlService.BASE_URL);
				string urlForColorName = client.BaseAddress + "api/DropDown/GetColorById?id="+id+"";
				var responseTask = client.GetAsync(urlForColorName);
				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					string apiResponse = await result.Content.ReadAsStringAsync();
					colorName = apiResponse;
				}
			}
			return Json(colorName);
        }

		[HttpGet]
		public async Task<IActionResult> GetSizebyId(int id)
		{
			string sizeName = "";
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(BaseUrlService.BASE_URL);
				string urlForSize = client.BaseAddress + "api/DropDown/GetSizeNameById?id="+id+"";
				var responseTask = client.GetAsync(urlForSize);
				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					string apiResponse = await result.Content.ReadAsStringAsync();
					sizeName = apiResponse;
				}
			}
			return Json(sizeName);
		}

		public IActionResult CheckOutIndex(decimal totalWithDelivery)
		{
			var cart = HttpContext.Session.GetString("Cart");
			ViewData["TotalWithDelivery"] = totalWithDelivery;
			var cartItems = string.IsNullOrEmpty(cart) ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(cart);

			return View(cartItems);
		}
		public IActionResult OrderPlaced()
		{
            HttpContext.Session.Clear();
            return View();	
		}

	}
}
