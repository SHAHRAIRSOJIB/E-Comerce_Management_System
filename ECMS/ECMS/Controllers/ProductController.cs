
using ECMS.Models;
using ECMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NuGet.Configuration;
using NuGet.Packaging.Signing;
using System.Text;

namespace ECMS.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IWebHostEnvironment hostEnvironment)
        {
            _webHostEnvironment = hostEnvironment;
        }
        public IActionResult ProductHomePage()
        {
            return View();
        }
        public async Task<IActionResult> AddProduct()
        {
            try
            {
                DropDownService dropDownService = new DropDownService();
                var categoryList = dropDownService.GetCategoryListAsync();
                var sizeList = dropDownService.GetSizeListAsync();
                var inventoryLevelList = dropDownService.GetInventoryLevelListAsync();
                var colorList = dropDownService.GetColorListAsync();
                ViewBag.CategoryList = new SelectList(categoryList.Result, "Id", "Name");
                ViewBag.SizeList = new SelectList(sizeList.Result, "Id", "Name");
                ViewBag.InventoryLevelList = new SelectList(inventoryLevelList.Result, "Id", "Lvl");
                ViewBag.ColorList = new SelectList(colorList.Result, "Id", "ColorName");

                return View();
            }
            catch
            {
                throw;
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Products products)
        {
            try
            {
                string filename = "";
                string filePath = "";
                string filePathForDb = "";
                if (products.ProductImage != null)
                {
                    string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "ProductPictures");
                    filename = Guid.NewGuid().ToString() + "_" + products.ProductImage.FileName;
                    filePath = Path.Combine(uploadFolder, filename);
                    filePathForDb = @"\ProductPictures\" + filename;

                    products.ProductImage.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                products.ImagePath = filePathForDb;
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(products);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BaseUrlService.BASE_URL);
                string postUrl = client.BaseAddress + "api/Product";
                HttpResponseMessage responseTask = await client.PostAsync(postUrl, content);

                if (responseTask.IsSuccessStatusCode)
                {
                    return Json(responseTask.IsSuccessStatusCode);
                }
                else
                {
                    return StatusCode((int)responseTask.StatusCode);
                }

            }
            catch
            {
                throw;
            }

        }

        public IActionResult ProductDetails(int id, string path, string name, string price, int color, int size, int qty)
        {
            ViewData["Id"] = id;
            ViewData["Path"] = path;
            ViewData["Name"] = name;
            ViewData["Price"] = price;
            ViewData["Color"] = color;
            ViewData["Size"] = size;
            ViewData["Qty"] = qty;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetProductById(int id) {
            try
            {
                Products products = new Products();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrlService.BASE_URL);
                    string urlForProduct = client.BaseAddress + "api/Product/GetById?id=" + id + "";
                    var responseTask = client.GetAsync(urlForProduct);
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        string apiResponse = await result.Content.ReadAsStringAsync();
                        products = JsonConvert.DeserializeObject<Products>(apiResponse);

                    }

                }
                return Json(products);
            }
            catch
            {
                throw;
            }

        }
        public IActionResult ViewCart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            return View(cart);
        }
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] Order perams)
        {
            try
            {
                perams.OrderDate = DateTime.Now;
                perams.OrderStatus = "Placed";
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(perams);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BaseUrlService.BASE_URL);
                string postUrl = client.BaseAddress + "api/Order";
                HttpResponseMessage responseTask = await client.PostAsync(postUrl, content);

                if (responseTask.IsSuccessStatusCode)
                {
                    return Json(responseTask.IsSuccessStatusCode);
                }
                else
                {
                    return StatusCode((int)responseTask.StatusCode);
                }

            }
            catch
            {
                throw;
            }

        }

        public IActionResult ProductList()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductList()
        {
            List<ProductDetailsView> productList = new List<ProductDetailsView>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrlService.BASE_URL);
                string url = client.BaseAddress + "api/Product/GetProductDetails";
                var responseTask = client.GetAsync(url);
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    string apiResponse = await result.Content.ReadAsStringAsync();
                    List<ProductDetailsView> itemList = JsonConvert.DeserializeObject<List<ProductDetailsView>>(apiResponse);
                    productList = itemList;
                    return Json(productList);
                }
                else
                {
                    return StatusCode((int)result.StatusCode);  
                }
            }
           
        }
        public IActionResult EditProduct(string productName, string productDescription, string productSpecification, string productPrice, string categoryName, string sizeName, string inventoryLevel, string quantity, string colorName, int productId)
        {
            DropDownService dropDownService = new DropDownService();
            var categoryList = dropDownService.GetCategoryListAsync();
            var sizeList = dropDownService.GetSizeListAsync();
            var inventoryLevelList = dropDownService.GetInventoryLevelListAsync();
            var colorList = dropDownService.GetColorListAsync();
            ViewBag.CategoryList = new SelectList(categoryList.Result, "Id", "Name");
            ViewBag.SizeList = new SelectList(sizeList.Result, "Id", "Name");
            ViewBag.InventoryLevelList = new SelectList(inventoryLevelList.Result, "Id", "Lvl");
            ViewBag.ColorList = new SelectList(colorList.Result, "Id", "ColorName");
            ViewBag.ProductName = productName;
            ViewBag.ProductDescription = productDescription;
            ViewBag.ProductSpecification = productSpecification;
            ViewBag.ProductPrice = productPrice;
            ViewBag.CategoryName = categoryName;
            ViewBag.SizeName = sizeName;
            ViewBag.InventoryLevel = inventoryLevel;
            ViewBag.Quantity = quantity;
            ViewBag.ColorName = colorName;
            ViewBag.ProductId = productId;

            return View();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]Products products)
        {
            try
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(products);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BaseUrlService.BASE_URL);
                string postUrl = client.BaseAddress + "api/Product";
                HttpResponseMessage responseTask = await client.PutAsync(postUrl, content);

                if (responseTask.IsSuccessStatusCode)
                {
                    return Json(responseTask.IsSuccessStatusCode);
                }
                else
                {
                    return StatusCode((int)responseTask.StatusCode);
                }
            }
            catch
            {
                throw;
            }

        }

    }
}
