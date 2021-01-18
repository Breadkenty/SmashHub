﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Users.UnbanUser
{
    public class UnbanUserRequest : IRequest<UnbanUserResponse>
    {
        public int UserId { get; set; }
        public int CurrentUserId { get; set; }
    }
}