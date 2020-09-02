using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Users.GetUser
{
    public class UserDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public UserType UserType { get; private set; }
    }
}
