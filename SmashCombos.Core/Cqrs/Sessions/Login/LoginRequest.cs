using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Sessions.Login
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
