using System;
using System.Collections.Generic;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Combos.PutCombo
{
    public class UserDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
    }
}
