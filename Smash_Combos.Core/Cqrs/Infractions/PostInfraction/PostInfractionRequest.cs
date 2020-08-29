using MediatR;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.PostInfraction
{
    public class PostInfractionRequest : IRequest<PostInfractionResponse>
    {
        public Infraction Infraction { get; set; }
        public int UserId { get; set; }
    }
}
