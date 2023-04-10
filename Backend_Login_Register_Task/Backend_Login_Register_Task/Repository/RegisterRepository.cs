using Backend_Login_Register_Task.Data;
using Backend_Login_Register_Task.Models;
using Backend_Login_Register_Task.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Login_Register_Task.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSetting _appsetting;
        public RegisterRepository(ApplicationDbContext context, IOptions<AppSetting> appSetting)
        {
            _context = context;
            _appsetting = appSetting.Value;
         

        }
        public Register Authenticate(string UserName, string password)
        {
            var UserIndb = _context.Registers.FirstOrDefault(r=>r.Username == UserName );
            if (UserIndb == null) return null;

            //Jwt Token
        
            var TokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(_appsetting.Secret);
            var TokenDescritor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //new Claim(ClaimTypes.Name, UserIndb.Id.ToString()),
                   
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var Token = TokenHandler.CreateToken(TokenDescritor);
            UserIndb.Token = TokenHandler.WriteToken(Token);

           // UserIndb.Password = "";
            return UserIndb;
        }

        public bool IsUniqueUser(string UserName)
        {
            var User = _context.Registers.FirstOrDefault(r=>r.Username == UserName);
            if (User == null)
                return true;
            else
                return false;
        }

        public Register Register(string UserName, string UserPassword)
        {
            Register register = new Register()
            {
                Username = UserName,
                Password = UserPassword
                
            };
            
            _context.Registers.Add(register);
            _context.SaveChanges();
            return register;
        }
    }
}
