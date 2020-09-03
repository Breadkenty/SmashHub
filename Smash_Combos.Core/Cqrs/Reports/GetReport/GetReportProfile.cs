using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.GetReport
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
