using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.DeleteInfraction
{
    public class DeleteInfractionResponse
    {
        public bool Success { get; set; }
        public InfractionDto Infraction { get; set; }
    }
}
