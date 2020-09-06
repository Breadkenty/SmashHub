using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.GetInfractionsByUser
{
    public class GetInfractionsByUserRequest : IRequest<GetInfractionsByUserResponse>
    {
        public int ModeratorId { get; set; }
        public string DisplayName { get; set; }
    }
}
