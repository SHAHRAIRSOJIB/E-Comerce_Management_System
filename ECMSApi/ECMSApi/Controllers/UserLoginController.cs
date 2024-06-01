using ECMSApi.Service.BussinessLayer.Interface;
using ECMSApi.Service.Model;
using Microsoft.AspNetCore.Mvc;

namespace ECMSApi.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLogin _login;
        public UserLoginController(IUserLogin login)
        {
                _login = login;    
        }
        [HttpGet]
        [Route("Login")]
        public UserLogin  Login(string email, string password)
        {
            var loginData = _login.UserLogin(email, password);
            return loginData;
        }
    }
}
