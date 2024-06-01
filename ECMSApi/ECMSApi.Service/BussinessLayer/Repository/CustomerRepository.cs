using ECMSApi.Service.BussinessLayer.Interface;
using ECMSApi.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.BussinessLayer.Repository
{
    public class CustomerRepository: ICustomer,IDisposable
    {
        private readonly ECMSContext _context;
        public CustomerRepository(ECMSContext context)
        {
            _context = context;
        }
        public int Add(Customer entity)
        {
            _context.Add(entity); 
            _context.SaveChanges();
            UserLogin userLogin = new UserLogin();
            userLogin.UserName = entity.Name;
            userLogin.Password = entity.Password;
            userLogin.Email = entity.Email;
            userLogin.Role = "Customer";
            _context.UserLogins.Add(userLogin);
            _context.SaveChanges();
            return entity.Id;   
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
