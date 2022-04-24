using AutoMapper;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Sessions.Login
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
