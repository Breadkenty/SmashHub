using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Characters.GetCharacters
{
    public class GetCharactersResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VariableName { get; set; }
        public int YPosition { get; set; }
        public decimal ReleaseOrder { get; set; }
        public List<Combo> Combos { get; set; }
    }
}
