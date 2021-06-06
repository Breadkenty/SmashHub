using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Infractions.DismissInfraction
{
    public class DismissInfractionRequest : IRequest<DismissInfractionResponse>
    {
        public int CurrentUserId { get; set; }
        public int InfractionId { get; set; }
        public bool Dismiss { get; set; }
    }
}
