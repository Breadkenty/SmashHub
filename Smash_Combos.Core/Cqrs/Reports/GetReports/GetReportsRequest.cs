using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.GetReports
{
    public class GetReportsRequest : IRequest<GetReportsResponse>
    {
        public int ModeratorId { get; set; }
    }
}
