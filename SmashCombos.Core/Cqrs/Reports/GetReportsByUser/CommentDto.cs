using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Reports.GetReportsByUser
{
    public class CommentDto
    {
        public int Id { get; set; }
        public DateTime DatePosted { get; private set; }
        public string Body { get; set; }
        public int NetVote { get; private set; }

        public ComboDto Combo { get; set; }
    }
}
