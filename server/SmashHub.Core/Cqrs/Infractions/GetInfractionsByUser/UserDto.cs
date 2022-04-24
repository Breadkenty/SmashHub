using System;
using System.Collections.Generic;
using System.Text;

namespace SmashHub.Core.Cqrs.Infractions.GetInfractionsByUser
{
    public class UserDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
    }
}
