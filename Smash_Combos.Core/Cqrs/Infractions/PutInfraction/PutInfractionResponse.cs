using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.PutInfraction
{
    public class PutInfractionResponse
    {
        public InfractionDto Infraction { get; set; }
        public bool Success { get; set; }
    }
}
