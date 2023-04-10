using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Login_Register_Task.Models.DTO
{
    public class RegisterDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
         public string ConfirmPassword { get; set; }
      

    }
}
