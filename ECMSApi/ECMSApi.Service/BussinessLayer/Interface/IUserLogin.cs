﻿using ECMSApi.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMSApi.Service.BussinessLayer.Interface
{
    public interface IUserLogin
    {
        public UserLogin UserLogin(string email, string password);
    }
}