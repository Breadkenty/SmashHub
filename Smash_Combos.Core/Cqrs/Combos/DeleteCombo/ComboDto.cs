using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Combos.DeleteCombo
{
    public class ComboDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CharacterId { get; set; }
        public DateTime DatePosted { get; set; }
        public string Title { get; set; }
    }
}
