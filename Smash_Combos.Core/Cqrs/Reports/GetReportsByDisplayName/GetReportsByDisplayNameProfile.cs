using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.GetReportsByDisplayName
{
    public class GetReportsByDisplayNameProfile : Profile
    {
        public GetReportsByDisplayNameProfile()
        {
            CreateMap<Report, GetReportsByDisplayNameResponse>();
            CreateMap<User, UserDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Combo, ComboDto>();
        }
    }
}
