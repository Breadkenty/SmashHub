using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Reports.GetReportsByUser
{
    public class UserDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
    }
}
