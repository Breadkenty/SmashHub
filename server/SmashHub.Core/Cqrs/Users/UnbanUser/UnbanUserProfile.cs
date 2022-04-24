using AutoMapper;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Users.UnbanUser
{
    public class UnbanUserProfile : Profile
    {
        public UnbanUserProfile()
        {
            CreateMap<User, UnbanUserResponse>();
            CreateMap<User, UserDto>();
            CreateMap<Combo, ComboDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Infraction, InfractionDto>();
        }
    }
}
