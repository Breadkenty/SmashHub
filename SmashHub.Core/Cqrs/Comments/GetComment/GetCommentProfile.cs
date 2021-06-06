using AutoMapper;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Comments.GetComment
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
