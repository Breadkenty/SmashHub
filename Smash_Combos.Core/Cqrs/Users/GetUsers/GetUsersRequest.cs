using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Users.GetUsers
{
    public class GetUsersRequest : IRequest<IEnumerable<GetUsersResponse>>
    {
        public int CurrentUserId { get; set; }
    }
}
