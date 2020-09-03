using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.GetReportByDisplayName
{
    public class GetReportByDisplayNameRequest : IRequest<IEnumerable<GetReportByDisplayNameResponse>>
    {
        public string DisplayName { get; set; }
    }
}
