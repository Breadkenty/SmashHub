using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Users.ResetPassword
{
    public class ResetPasswordRequest : IRequest<ResetPasswordResponse>
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public string ResetPassword { get; set; }
    }
}
