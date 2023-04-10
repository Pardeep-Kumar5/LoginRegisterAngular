using Backend_Login_Register_Task.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Login_Register_Task.Repository.IRepository
{
   public interface IRegisterRepository
    {
        bool IsUniqueUser(string UserName);
        Register Authenticate(string UserName,string password);
        Register Register(string UserName, string UserPassword);
    }
}
