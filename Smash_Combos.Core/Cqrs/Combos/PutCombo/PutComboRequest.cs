using MediatR;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Combos.PutCombo
{
    public class PutComboRequest : IRequest<PutComboResponse>
    {
        public int ComboId { get; set; }
        public int UserId { get; set; }
        public Combo Combo { get; set; }
    }
}
