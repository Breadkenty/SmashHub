using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Users.UnbanUser
{
    public class InfractionDto
    {
        public int Id { get; set; }

        public UserDto User { get; set; }

        public UserDto Moderator { get; set; }

        public int? BanDuration { get; set; }

        public DateTime? BanLiftDate { get; set; }

        public int? Points { get; private set; }

        public InfractionCategory Category { get; set; }

        public string Body { get; set; }

        public DateTime DateInfracted { get; set; }
    }
}
