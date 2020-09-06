using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.GetReportsByUser
{
    public class GetReportsByUserProfile : Profile
    {
        public GetReportsByUserProfile()
        {
            CreateMap<Report, ReportDto>();
            CreateMap<User, UserDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Combo, ComboDto>();
            CreateMap<Character, CharacterDto>();
        }
    }
}
