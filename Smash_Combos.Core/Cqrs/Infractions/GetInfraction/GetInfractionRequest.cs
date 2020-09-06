using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.GetInfraction
{
    public class GetInfractionRequest : IRequest<GetInfractionResponse>
    {
        public int InfractionId { get; set; }
        public int ModeratorId { get; set; }
    }
}
