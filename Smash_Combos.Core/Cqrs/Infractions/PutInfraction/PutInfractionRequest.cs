using MediatR;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.PutInfraction
{
    public class PutInfractionRequest : IRequest<PutInfractionResponse>
    {
        public int Id { get; set; }
        public int? BanDuration { get; set; }
        public int? Points { get; set; }
        public InfractionCategory Category { get; set; }
        public string Body { get; set; }
        public bool LiftBan { get; set; }
    }
}
