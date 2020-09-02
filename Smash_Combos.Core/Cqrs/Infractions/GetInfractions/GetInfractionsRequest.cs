using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.GetInfractions
{
    public class GetInfractionsRequest : IRequest<IEnumerable<GetInfractionsResponse>>
    {
    }
}
