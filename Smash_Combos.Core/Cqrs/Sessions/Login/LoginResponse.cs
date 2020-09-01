using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Sessions.Login
{
    public class LoginResponse
    {
        public string ResponseMessage { get; set; }
        public string Token { get; set; }
        public UserDto User { get; set; }
        public bool PasswordIsValid { get; set; }
    }
}
