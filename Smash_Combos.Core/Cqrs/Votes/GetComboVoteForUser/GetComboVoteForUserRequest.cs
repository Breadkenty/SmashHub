using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Votes.GetComboVoteForUser
{
    public class GetComboVoteForUserRequest : IRequest<GetComboVoteForUserResponse>
    {
        public int ComboId { get; set; }
        public int UserId { get; set; }
    }
}
