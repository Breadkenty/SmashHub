using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.DismissInfraction
{
    public class DismissInfractionRequest : IRequest<DismissInfractionResponse>
    {
        public int ModeratorId { get; set; }
        public int InfractionId { get; set; }
        public bool Dismiss { get; set; }
    }
}
