using ECMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ECMS.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CustomerController(IWebHostEnvironment hostEnvironment)
        {
            _webHostEnvironment = hostEnvironment;
        }
        public IActionResult RegisterCustomer()
        {
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> PostCustomer([FromBody]Customer customer)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(customer);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrlService.BASE_URL);
            string postUrl = client.BaseAddress + "api/Customer";
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
    }
}
