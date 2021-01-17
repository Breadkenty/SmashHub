using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Characters.GetCharacter
{
    public class ComboDto
    {
        public int Id { get; set; }

        public UserDto User { get; set; }

        public DateTime DatePosted { get; private set; }

        public string Title { get; set; }

        public string ComboInput { get; set; }

        public bool TrueCombo { get; set; }

        public string Difficulty { get; set; }

        public int Damage { get; set; }

        public int NetVote { get; private set; }
    }
}
