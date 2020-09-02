using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Users.UnbanUser
{
    public class UnbanUserRequest : IRequest<UnbanUserResponse>
    {
        public string DisplayName { get; set; }
        public string ModeratorDisplayName { get; set; }
    }
}
