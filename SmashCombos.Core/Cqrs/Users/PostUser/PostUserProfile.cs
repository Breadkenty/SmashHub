using AutoMapper;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Users.PostUser
{
    public class PostUserProfile : Profile
    {
        public PostUserProfile()
        {
            CreateMap<PostUserRequest, User>();
            CreateMap<User, PostUserResponse>();
        }
    }
}
