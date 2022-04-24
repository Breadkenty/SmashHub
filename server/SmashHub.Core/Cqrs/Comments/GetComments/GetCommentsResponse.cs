using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Comments.GetComments
{
    public class GetCommentsResponse
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public DateTime DatePosted { get; private set; }
        public string Body { get; set; }
        public int NetVote { get; private set; }
    }
}
