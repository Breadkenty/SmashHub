using MediatR;
using Microsoft.AspNetCore.Identity;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Users.PostUser
{
    public class PostUserRequest : IRequest<PostUserResponse>
    {
        public User User { get; set; }
    }
}
