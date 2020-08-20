using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Combos.DeleteCombo
{
    public class DeleteComboResponse
    {
        public bool Success { get; set; }
        public ComboDto Combo { get; set; }
    }
}
