using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.PostComboReport
{
    public class PostComboReportProfile : Profile
    {
        public PostComboReportProfile()
        {
            CreateMap<Report, ReportDto>();
            CreateMap<User, UserDto>();
        }
    }
}
