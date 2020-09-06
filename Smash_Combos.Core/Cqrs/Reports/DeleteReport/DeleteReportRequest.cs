using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.DeleteReport
{
    public class DeleteReportRequest : IRequest<DeleteReportResponse>
    {
        public int ReportId { get; set; }
        public int ModeratorId { get; set; }
    }
}
