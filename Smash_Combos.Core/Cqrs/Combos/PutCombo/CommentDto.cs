using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Combos.PutCombo
{
    public class CommentDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public DateTime DatePosted { get; private set; }
        public string Body { get; set; }
        public int NetVote { get; private set; }
    }
}
