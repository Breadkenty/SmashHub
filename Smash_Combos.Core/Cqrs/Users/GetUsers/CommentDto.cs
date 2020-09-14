using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Users.GetUsers
{
    public class CommentDto
    {
        public int Id { get; set; }
        public DateTime DatePosted { get; set; }
        public string Body { get; set; }
        public List<ReportDto> Reports { get; set; } = new List<ReportDto>();
        public int NetVote { get; private set; }
    }
}
