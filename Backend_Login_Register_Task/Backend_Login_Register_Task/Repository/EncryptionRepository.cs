using Backend_Login_Register_Task.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Login_Register_Task.Repository
{
    public class EncryptionRepository : IEncryptionRepository
    {

        public string EncryptPassword(string password)
        {
            byte[] pwd = Encoding.ASCII.GetBytes(password);
            string encodedData = Convert.ToBase64String(pwd);
            return encodedData;
        }

        public string DecryptPassword(string password)
        {
            byte[] pwd = Encoding.ASCII.GetBytes(password);
            string encodedData = Convert.ToBase64String(pwd);
            return encodedData;
        }
    }
}
