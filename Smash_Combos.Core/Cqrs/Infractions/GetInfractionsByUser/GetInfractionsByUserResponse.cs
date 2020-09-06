using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.GetInfractionsByUser
{
    public class GetInfractionsByUserResponse : ResponseBase<IEnumerable<InfractionDto>>
    {
    }
}
