using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.GetInfractions
{
    public class GetInfractionsRequest : IRequest<GetInfractionsResponse>
    {
        public int ModeratorId { get; set; }
    }
}
