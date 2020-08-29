using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.PutReport
{
    public class PutReportProfile : Profile
    {
        public PutReportProfile()
        {
            CreateMap<Report, ReportDto>();
            CreateMap<User, UserDto>();
        }
    }
}
