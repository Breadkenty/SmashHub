using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Sessions.Login
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}
