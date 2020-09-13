using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Votes.PostComboVote
{
    public class PostComboVoteRequest : IRequest<PostComboVoteResponse>
    {
        public int ComboId { get; set; }
        public int CurrentUserId { get; set; }
        public string UpOrDown { get; set; }
    }
}
