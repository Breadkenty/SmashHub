using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Users.NewPassword
{
    public class NewPasswordRequest : IRequest<NewPasswordResponse>
    {
        public int Userid { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
