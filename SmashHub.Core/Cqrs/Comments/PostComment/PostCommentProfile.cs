using AutoMapper;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Comments.PostComment
{
    public class PostCommentProfile : Profile
    {
        public PostCommentProfile()
        {
            CreateMap<Comment, PostCommentResponse>();
            CreateMap<User, UserDto>();
        }
    }
}
