using MediatR;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Users.GetUser
{
    public class GetUserRequest : IRequest<GetUserResponse>
    {
        public string DisplayName { get; set; }
        public int CurrentUserId { get; set; }
    }
}
