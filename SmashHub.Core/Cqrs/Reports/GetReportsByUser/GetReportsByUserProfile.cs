using AutoMapper;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Reports.GetReportsByUser
{
    public class GetReportsByUserProfile : Profile
    {
        public GetReportsByUserProfile()
        {
            CreateMap<Report, GetReportsByUserResponse>();
            CreateMap<User, UserDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Combo, ComboDto>();
            CreateMap<Character, CharacterDto>();
        }
    }
}
