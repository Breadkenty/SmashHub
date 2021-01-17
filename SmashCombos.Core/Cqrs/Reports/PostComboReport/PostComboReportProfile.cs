using AutoMapper;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Reports.PostComboReport
{
    public class PostComboReportProfile : Profile
    {
        public PostComboReportProfile()
        {
            CreateMap<Report, PostComboReportResponse>();
            CreateMap<User, UserDto>();
        }
    }
}
