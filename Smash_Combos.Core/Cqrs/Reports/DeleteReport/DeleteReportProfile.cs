using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.DeleteReport
{
    public class DeleteReportProfile : Profile
    {
        public DeleteReportProfile()
        {
            CreateMap<Report, ReportDto>();
            CreateMap<User, UserDto>();
        }
    }
}
