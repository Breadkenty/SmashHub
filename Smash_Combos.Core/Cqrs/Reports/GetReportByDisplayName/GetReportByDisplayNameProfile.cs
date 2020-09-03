using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.GetReportByDisplayName
{
    public class GetReportByDisplayNameProfile : Profile
    {
        public GetReportByDisplayNameProfile()
        {
            CreateMap<Report, GetReportByDisplayNameResponse>();
            CreateMap<User, UserDto>();
        }
    }
}
