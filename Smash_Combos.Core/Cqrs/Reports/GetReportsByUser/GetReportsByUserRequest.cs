using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.GetReportsByUser
{
    public class GetReportsByUserRequest : IRequest<IEnumerable<GetReportsByUserResponse>>
    {
        public string DisplayName { get; set; }
        public int CurrentUserId { get; set; }
    }
}
