using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Users.ForgotPassword
{
    public class ForgotPasswordResponse
    {
        public string ResponseMessage { get; set; }
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}
