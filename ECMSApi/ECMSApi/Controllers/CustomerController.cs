using ECMSApi.Service.BussinessLayer.Interface;
using ECMSApi.Service.Model;
using Microsoft.AspNetCore.Mvc;

namespace ECMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customer;
        public CustomerController(ICustomer customer)
        {
             _customer = customer;
        }
        [HttpPost]
        public int Add(Customer entity)
        {
            _customer.Add(entity);
            return entity.Id;   
        }
    }
}
