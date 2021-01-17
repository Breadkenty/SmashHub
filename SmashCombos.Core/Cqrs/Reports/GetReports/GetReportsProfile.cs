using AutoMapper;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Reports.GetReports
{
    public class GetReportsProfile : Profile
    {
        public GetReportsProfile()
        {
            CreateMap<Report, GetReportsResponse>();
            CreateMap<User, UserDto>();
            CreateMap<Combo, ComboDto>();
            CreateMap<Comment, CommentDto>();
        }
    }
}
