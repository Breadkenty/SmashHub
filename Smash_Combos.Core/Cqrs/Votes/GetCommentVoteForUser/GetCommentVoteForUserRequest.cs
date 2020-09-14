using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Votes.GetCommentVoteForUser
{
    public class GetCommentVoteForUserRequest : IRequest<GetCommentVoteForUserResponse>
    {
        public int UserId { get; set; }
        public int CommentId { get; set; }
    }
}
