using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Comments.GetComments
{
    public class GetCommentsRequest : IRequest<IEnumerable<GetCommentsResponse>>
    {
    }
}
