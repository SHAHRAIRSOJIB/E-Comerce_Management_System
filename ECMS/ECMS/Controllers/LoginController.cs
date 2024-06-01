using ECMS.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECMS.Controllers
{
	public class LoginController : Controller
	{
        private readonly IHttpContextAccessor _contextAccessor;
        public LoginController(IHttpContextAccessor httpContextAccessor)
        {
                _contextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
		{
			return View();
		}
        [HttpPost]
		public async Task<IActionResult> UserLoginInfo(string email, string password)
		{
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrlService.BASE_URL);
            string postUrl = client.BaseAddress + "api/UserLogin/Login?email="+ email + "&password="+ password + "";
            HttpResponseMessage responseTask = await client.GetAsync(postUrl);
            UserLogin loginData = new UserLogin();
            if (responseTask.IsSuccessStatusCode)
            {
                string jsonResponse = await responseTask.Content.ReadAsStringAsync();

                loginData = JsonConvert.DeserializeObject<UserLogin>(jsonResponse);
                if (loginData != null)
                {
                    _contextAccessor.HttpContext.Session.SetInt32("UserId", loginData.Id);
                    _contextAccessor.HttpContext.Session.SetString("UserName", loginData.UserName);
                    _contextAccessor.HttpContext.Session.SetString("Email", loginData.Email);
                    _contextAccessor.HttpContext.Session.SetString("Role", loginData.Role);
                }
                
                return Json(loginData);
            }
            else
            {
               
                return Json(responseTask.StatusCode);
            }
        }

        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminLogin(string email, string password)
        {
             HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrlService.BASE_URL);
            string postUrl = client.BaseAddress + "api/UserLogin/Login?email="+ email + "&password="+ password + "";
            HttpResponseMessage responseTask = await client.GetAsync(postUrl);
            UserLogin loginData = new UserLogin();
            if (responseTask.IsSuccessStatusCode)
            {
                string jsonResponse = await responseTask.Content.ReadAsStringAsync();

                loginData = JsonConvert.DeserializeObject<UserLogin>(jsonResponse);
                if (loginData != null)
                {
                    _contextAccessor.HttpContext.Session.SetInt32("UserId", loginData.Id);
                    _contextAccessor.HttpContext.Session.SetString("UserName", loginData.UserName);
                    _contextAccessor.HttpContext.Session.SetString("Email", loginData.Email);
                    _contextAccessor.HttpContext.Session.SetString("Role", loginData.Role);
                }
                return Json(loginData);
            }
            else
            {
                return Json(responseTask.StatusCode);
            }

        }

        public IActionResult LogOut()
        {
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			HttpContext.Session.Clear();
			return RedirectToAction("ProductHomePage", "Product");
		}

    }
}
