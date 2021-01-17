using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Comments.PostComment
{
    public class PostCommentRequest : IRequest<PostCommentResponse>
    {
        public int CurrentUserId { get; set; }
        public int ComboId { get; set; }
        public string Body { get; set; }
    }
}
