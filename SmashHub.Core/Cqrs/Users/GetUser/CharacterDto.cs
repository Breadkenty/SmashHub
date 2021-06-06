using SmashHub.Domain.Models;

namespace SmashHub.Core.Cqrs.Users.GetUser
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string VariableName { get; set; }
    }
}