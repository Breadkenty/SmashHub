using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.PutReport
{
    public class PutReportResponse
    {
        public ReportDto Report { get; set; }
        public bool Success { get; set; }
    }
}
