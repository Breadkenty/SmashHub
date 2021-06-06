using AutoMapper;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Reports.GetReport
{
    public class GetReportProfile : Profile
    {
        public GetReportProfile()
        {
            CreateMap<Report, GetReportResponse>();
            CreateMap<User, UserDto>();
            CreateMap<Combo, ComboDto>();
            CreateMap<Comment, CommentDto>();
        }
    }
}
