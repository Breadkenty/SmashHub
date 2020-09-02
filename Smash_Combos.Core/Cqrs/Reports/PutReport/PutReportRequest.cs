using MediatR;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.PutReport
{
    public class PutReportRequest : IRequest<PutReportResponse>
    {
        public int Id { get; set; }
        public bool Dismiss { get; set; }
    }
}
