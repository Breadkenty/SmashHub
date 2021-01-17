using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Infractions.DeleteInfraction
{
    public class DeleteInfractionRequest : IRequest<DeleteInfractionResponse>
    {
        public int InfractionId { get; set; }
        public int CurrentUserId { get; set; }
    }
}
