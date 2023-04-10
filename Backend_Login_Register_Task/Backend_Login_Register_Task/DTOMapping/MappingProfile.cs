using AutoMapper;
using Backend_Login_Register_Task.Models;
using Backend_Login_Register_Task.Models.DTO;
using Backend_Login_Register_Task.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Login_Register_Task.DTOMapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDto, Register>().ReverseMap();
            CreateMap<LoginDto, LoginVM>().ReverseMap();

        }
    }
}
