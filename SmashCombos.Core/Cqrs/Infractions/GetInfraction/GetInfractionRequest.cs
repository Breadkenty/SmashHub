using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Infractions.GetInfraction
{
    public class GetInfractionRequest : IRequest<GetInfractionResponse>
    {
        public int InfractionId { get; set; }
        public int CurrentUserId { get; set; }
    }
}
