using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Comments.PutComment
{
    public class PutCommentRequest : IRequest<PutCommentResponse>
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public string Body { get; set; }
    }
}
