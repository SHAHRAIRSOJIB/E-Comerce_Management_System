using ECMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECMS.Controllers
{
	public class CartController : Controller
	{
        public IActionResult AddToCart(int id, string path, string name, string price, int color, int size, int qty)
        {
            // Extract the required part of the path
            var fileName = path.Replace("ProductPictures", "");
            var fileName2 = System.IO.Path.GetFileName(path);
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            // Check if the item already exists in the cart
            var existingCartItem = cart.FirstOrDefault(c => c.Id == id && c.Color == color && c.Size == size);

            if (existingCartItem != null)
            {
                // If the item exists, increase the quantity
                existingCartItem.Qty += qty;
            }
            else
            {
                // If the item does not exist, add it as a new item
                var cartItem = new CartItem
                {
                    Id = id,
                    Path = fileName,
                    Name = name,
                    Price = price,
                    Color = color,
                    Size = size,
                    Qty = qty
                };

                cart.Add(cartItem);
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return RedirectToAction("Index", "Home"); // Adjust redirection as needed
        }

        
    }
}
