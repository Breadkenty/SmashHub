using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        [InverseProperty("Infractions")]
        public User User { get; set; }

        public User Moderator { get; set; }

        public int? BanDuration { get; set; }
        
        public DateTime? BanLiftDate { get; set; }

        public int? Points { get; private set; }

        public InfractionCategory Category { get; private set; }

        [Required]
        public string Body { get; set; }

        public DateTime DateInfracted { get; private set; }
    }
}
