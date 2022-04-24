using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Users.PostUser
{
    public class PostUserResponse
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public UserType UserType { get; private set; }
    }
}
