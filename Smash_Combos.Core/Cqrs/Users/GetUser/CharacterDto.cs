using Smash_Combos.Domain.Models;

namespace Smash_Combos.Core.Cqrs.Users.GetUser
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string VariableName { get; set; }
    }
}