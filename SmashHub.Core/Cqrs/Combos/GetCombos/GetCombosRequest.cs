using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Combos.GetCombos
{
    public class GetCombosRequest : IRequest<IEnumerable<GetCombosResponse>>
    {
    }
}
