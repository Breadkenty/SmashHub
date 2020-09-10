using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Users.ForgotPassword
{
    public class ForgotPasswordProfile : Profile
    {
        public ForgotPasswordProfile()
        {
            CreateMap<ForgotPasswordRequest, User>();
            CreateMap<User, UserDto>();
        }
    }
}
