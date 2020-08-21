using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Combos.PutCombo
{
    public class PutComboResponse
    {
        public bool Success { get; set; }
        public ComboDto Combo { get; set; }
    }
}
