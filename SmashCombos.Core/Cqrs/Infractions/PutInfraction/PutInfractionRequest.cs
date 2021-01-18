﻿using MediatR;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmashCombos.Core.Cqrs.Infractions.PutInfraction
{
    public class PutInfractionRequest : IRequest<PutInfractionResponse>
    {
        public int CurrentUserId { get; set; }
        [Required]
        public int InfractionId { get; set; }
        [Required]
        public int? BanDuration { get; set; }
        [Required]
        public int? Points { get; set; }
        [Required]
        public InfractionCategory Category { get; set; }
        [Required]
        public string Body { get; set; }
    }
}