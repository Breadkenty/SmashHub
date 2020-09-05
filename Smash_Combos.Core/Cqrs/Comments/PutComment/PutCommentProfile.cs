using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Comments.PutComment
{
    public class PutCommentProfile : Profile
    {
        public PutCommentProfile()
        {
            CreateMap<Comment, CommentDto>();
            CreateMap<User, UserDto>();
        }
    }
}
