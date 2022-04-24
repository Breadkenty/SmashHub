using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Comments.DeleteComment
{
    public class DeleteCommentRequest : IRequest<DeleteCommentResponse>
    {
        public int CommentId { get; set; }
        public int CurrentUserId { get; set; }
    }
}
