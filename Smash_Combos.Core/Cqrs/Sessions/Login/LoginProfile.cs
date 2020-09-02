using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Sessions.Login
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
