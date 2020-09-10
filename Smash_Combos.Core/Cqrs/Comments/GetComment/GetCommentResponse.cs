using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Comments.GetComment
{
    public class GetCommentResponse
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public int ComboId { get; set; }
        public DateTime DatePosted { get; private set; }
        public string Body { get; set; }
        public List<ReportDto> Reports { get; set; }
    }
}
