﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.DeleteInfraction
{
    public class DeleteInfractionRequest : IRequest<DeleteInfractionResponse>
    {
        public int InfractionId { get; set; }
        public int CurrentUserId { get; set; }
    }
}
