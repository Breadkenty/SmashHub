using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Comments.PostComment
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
