using MediatR;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.DismissReport
{
    public class DismissReportRequest : IRequest<DismissReportResponse>
    {
        public int ReportId { get; set; }
        public int CurrentUserId { get; set; }
        public bool Dismiss { get; set; }
    }
}
