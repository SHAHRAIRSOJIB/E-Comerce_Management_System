using ECMSApi.Service.BussinessLayer.Interface;
using ECMSApi.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.BussinessLayer.Repository
{
    public class UserLoginRepository: IUserLogin,IDisposable
    {
        private readonly ECMSContext _context;
        public UserLoginRepository(ECMSContext context)
        {
                _context = context;
        }

       
        public UserLogin UserLogin(string email, string password)
        {
            UserLogin data = new UserLogin();
            data = _context.UserLogins.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            if(data != null)
            {
             return data;
            }
            else
            {
                return null;
            }

        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
