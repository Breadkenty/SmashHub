using AutoMapper;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Users.GetUser
{
    public class GetUserProfile : Profile
    {
        public GetUserProfile()
        {
            CreateMap<Character, CharacterDto>();
            CreateMap<User, UserDto>();
            CreateMap<Combo, ComboDto>();
            CreateMap<Report, ReportDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Infraction, InfractionDto>();
        }
    }
}
