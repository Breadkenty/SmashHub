using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Infractions.GetInfractions
{
    public class GetInfractionsRequest : IRequest<IEnumerable<GetInfractionsResponse>>
    {
        public int CurrentUserId { get; set; }
    }
}
