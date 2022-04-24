using AutoMapper;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Users.GetUsers
{
    public class GetUsersProfile : Profile
    {
        public GetUsersProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Combo, ComboDto>();
            CreateMap<Report, ReportDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Infraction, InfractionDto>();
        }
    }
}
