using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Comments.GetComment
{
    public class GetCommentRequest : IRequest<GetCommentResponse>
    {
        public int CommentId { get; set; }
    }
}
