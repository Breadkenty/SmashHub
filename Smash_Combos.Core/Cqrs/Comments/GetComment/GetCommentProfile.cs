using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Comments.GetComment
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
