using MediatR;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Reports.PostComboReport
{
    public class PostComboReportRequest : IRequest<PostComboReportResponse>
    {
        public int UserId { get; set; }

        public int ReporterId { get; set; }

        public int ComboId { get; set; }

        public string Body { get; set; }
    }
}
