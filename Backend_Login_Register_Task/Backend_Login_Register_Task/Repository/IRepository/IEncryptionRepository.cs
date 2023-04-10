﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Login_Register_Task.Repository.IRepository
{
   public interface IEncryptionRepository
    {
        string EncryptPassword(string password);
        string DecryptPassword(string password);
    }
}
