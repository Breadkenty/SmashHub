using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Reports.GetReports
{
    public class GetReportsRequest : IRequest<IEnumerable<GetReportsResponse>>
    {
        public int CurrentUserId { get; set; }
    }
}
