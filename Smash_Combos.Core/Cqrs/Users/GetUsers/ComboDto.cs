using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Users.GetUsers
{
    public class ComboDto
    {
        public int Id { get; set; }

        public int CharacterId { get; set; }

        public DateTime DatePosted { get; set; }

        public List<ReportDto> Reports { get; set; } = new List<ReportDto>();

        public string Title { get; set; }
    }
}
