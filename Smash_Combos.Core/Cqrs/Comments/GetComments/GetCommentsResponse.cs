using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Comments.GetComments
{
    public class GetCommentsResponse : ResponseBase<IEnumerable<CommentDto>>
    {
    }
}
