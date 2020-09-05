using MediatR;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Reports.PostComboReport
{
    public class PostComboReportRequest : IRequest<PostComboReportResponse>
    {
        public UserDto User { get; set; }

        public UserDto Reporter { get; set; }

        public int ComboId { get; set; }

        public string Body { get; set; }
    }
}
