using System.Collections.Generic;

namespace Smash_Combos.Core.Cqrs.Characters.GetCharacter
{
    public class GetCharacterResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VariableName { get; set; }
        public int YPosition { get; set; }
        public decimal ReleaseOrder { get; set; }
        public List<ComboDto> Combos { get; set; }
    }
}