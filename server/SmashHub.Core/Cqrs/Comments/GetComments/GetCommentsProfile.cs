using AutoMapper;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Comments.GetComments
{
    public class GetCommentsProfile : Profile
    {
        public GetCommentsProfile()
        {
            CreateMap<Comment, GetCommentsResponse>();
            CreateMap<User, UserDto>();
            CreateMap<Report, ReportDto>();
        }
    }
}
