using AutoMapper;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Reports.PostCommentReport
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
