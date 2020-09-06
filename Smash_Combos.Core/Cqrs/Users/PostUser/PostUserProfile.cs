using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Users.PostUser
{
    public class PostUserProfile : Profile
    {
        public PostUserProfile()
        {
            CreateMap<PostUserRequest, User>();
            CreateMap<User, UserDto>();
        }
    }
}
