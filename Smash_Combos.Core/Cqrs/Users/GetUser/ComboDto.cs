using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Users.GetUser
{
    public class ComboDto
    {
        public int Id { get; set; }

        public CharacterDto Character { get; set; }

        public DateTime DatePosted { get; set; }

        public List<ReportDto> Reports { get; set; } = new List<ReportDto>();

        public string Title { get; set; }
        public int NetVote { get; set; }
        public string ComboInput { get; set; }
    }
}
