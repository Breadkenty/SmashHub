using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Users.GetUsers
{
    public class GetUsersRequest : IRequest<IEnumerable<GetUsersResponse>>
    {
        public int CurrentUserId { get; set; }
    }
}
