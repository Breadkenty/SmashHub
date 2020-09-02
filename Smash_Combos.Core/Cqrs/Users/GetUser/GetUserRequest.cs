using MediatR;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Users.GetUser
{
    public class GetUserRequest : IRequest<GetUserResponse>
    {
        public string DisplayName { get; set; }
    }
}
