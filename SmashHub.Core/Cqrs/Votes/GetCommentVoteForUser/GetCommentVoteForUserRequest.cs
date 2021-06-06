using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Votes.GetCommentVoteForUser
{
    public class GetCommentVoteForUserRequest : IRequest<GetCommentVoteForUserResponse>
    {
        public int UserId { get; set; }
        public int CommentId { get; set; }
    }
}
