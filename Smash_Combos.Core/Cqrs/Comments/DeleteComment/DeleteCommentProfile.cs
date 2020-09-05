using AutoMapper;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Comments.DeleteComment
{
    public class DeleteCommentProfile : Profile
    {
        public DeleteCommentProfile()
        {
            CreateMap<Comment, CommentDto>();
            CreateMap<User, UserDto>();
        }
    }
}
