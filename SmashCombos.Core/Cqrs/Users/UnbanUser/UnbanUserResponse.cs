using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmashCombos.Core.Cqrs.Users.UnbanUser
{
    public class UnbanUserResponse
    {
        public int Id { get; set; }

        public string DisplayName { get; set; }

        public UserType UserType { get; set; }

        public List<ComboDto> Combos { get; set; }

        public List<CommentDto> Comments { get; set; }

        public List<InfractionDto> Infractions { get; set; }
    }
}
