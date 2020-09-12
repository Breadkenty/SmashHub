using MediatR;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.PostInfraction
{
    public class PostInfractionRequest : IRequest<PostInfractionResponse>
    {
        public int UserId { get; set; }

        public int CurrentUserId { get; set; }

        public int? BanDuration { get; set; }

        public int? Points { get; set; }

        public InfractionCategory Category { get; set; }

        public string Body { get; set; }

    }
}
