using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Infractions.GetInfractionsByUser
{
    public class GetInfractionsByUserResponse
    {
        public int Id { get; set; }

        public UserDto User { get; set; }

        public UserDto Moderator { get; set; }

        public int? BanDuration { get; set; }

        public DateTime? BanLiftDate { get; set; }

        public int? Points { get; set; }

        public InfractionCategory Category { get; set; }

        public string Body { get; set; }

        public DateTime DateInfracted { get; private set; }
    }
}
