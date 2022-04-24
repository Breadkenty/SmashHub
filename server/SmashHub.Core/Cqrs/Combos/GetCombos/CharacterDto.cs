using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Combos.GetCombos
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VariableName { get; set; }
        public int YPosition { get; set; }
        public decimal ReleaseOrder { get; set; }
    }
}
