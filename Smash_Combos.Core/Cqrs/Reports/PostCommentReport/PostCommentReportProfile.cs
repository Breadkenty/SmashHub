using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.PostCommentReport
{
    public class PostCommentReportProfile : Profile
    {
        public PostCommentReportProfile()
        {
            CreateMap<Report, PostCommentReportResponse>();
            CreateMap<User, UserDto>();
        }
    }
}
