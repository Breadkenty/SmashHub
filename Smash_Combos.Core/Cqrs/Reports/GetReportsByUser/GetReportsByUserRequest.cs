using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.GetReportsByUser
{
    public class GetReportsByUserRequest : IRequest<GetReportsByUserResponse>
    {
        public string UserName { get; set; }
        public int ModeratorId { get; set; }
    }
}
