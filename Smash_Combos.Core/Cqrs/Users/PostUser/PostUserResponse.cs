using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Users.PostUser
{
    public class PostUserResponse
    {
        public User User { get; set; }

        public bool EmailAlreadyExists { get; set; }
        public bool DisplayNameAlreadyExists { get; set; }
        public bool PasswordDoesntMeetCriteria { get; set; }
    }
}
