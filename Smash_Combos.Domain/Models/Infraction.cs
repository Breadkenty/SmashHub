using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Smash_Combos.Domain.Models
{
    public class Infraction
    {
        public Infraction()
        {
            this.DateInfracted = DateTime.Now;
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public int ModeratorId { get; set; }

        public int BanDuration { get; set; }

        public int Points { get; private set; }

        [Required]
        public string Body { get; set; }

        public DateTime DateInfracted { get; private set; }
    }
}
