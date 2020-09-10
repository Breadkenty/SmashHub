using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Users.ForgotPassword
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }

    }
}
