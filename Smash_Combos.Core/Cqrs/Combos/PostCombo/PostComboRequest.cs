using MediatR;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Combos.PostCombo
{
    public class PostComboRequest : IRequest<PostComboResponse>
    {
        public Combo Combo { get; set; }
        public int UserId { get; set; }
    }
}
