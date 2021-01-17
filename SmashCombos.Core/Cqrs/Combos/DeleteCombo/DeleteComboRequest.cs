using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Combos.DeleteCombo
{
    public class DeleteComboRequest : IRequest<DeleteComboResponse>
    {
        public int ComboId { get; set; }
        public int CurrentUserId { get; set; }
    }
}
