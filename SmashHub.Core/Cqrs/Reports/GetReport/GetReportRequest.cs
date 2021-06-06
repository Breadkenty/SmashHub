using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Reports.GetReport
{
    public class GetReportRequest : IRequest<GetReportResponse>
    {
        public int ReportId { get; set; }
        public int CurrentUserId { get; set; }
    }
}
