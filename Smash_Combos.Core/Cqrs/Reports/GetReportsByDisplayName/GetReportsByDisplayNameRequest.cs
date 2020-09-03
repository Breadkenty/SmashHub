using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.GetReportsByDisplayName
{
    public class GetReportsByDisplayNameRequest : IRequest<IEnumerable<GetReportsByDisplayNameResponse>>
    {
        public string DisplayName { get; set; }
    }
}
