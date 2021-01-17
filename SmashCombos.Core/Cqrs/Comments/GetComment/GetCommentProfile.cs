using AutoMapper;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Comments.GetComment
{
    public class GetCommentProfile : Profile
    {
        public GetCommentProfile()
        {
            CreateMap<Comment, GetCommentResponse>();
            CreateMap<User, UserDto>();
            CreateMap<Report, ReportDto>();
        }
    }
}
