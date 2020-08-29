using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.GetReport
{
    public class GetReportRequest : IRequest<GetReportResponse>
    {
        public int ReportId { get; set; }
    }
}
