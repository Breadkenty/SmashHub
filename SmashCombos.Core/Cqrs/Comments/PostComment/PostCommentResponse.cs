using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Comments.PostComment
{
    public class PostCommentResponse
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public DateTime DatePosted { get; private set; }
        public string Body { get; set; }
        public int NetVote { get; private set; }
    }
}
