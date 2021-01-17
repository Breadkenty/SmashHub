using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmashCombos.Domain.Models
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
        
        public DateTime? DismissDate { get; set; }

        public int? Points { get; set; }

        public InfractionCategory Category { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime DateInfracted { get; private set; }

        public bool IsActiveBan()
        {
            if (BanDuration == null)
                return false;

            if (DismissDate != null && DismissDate < DateTime.Now)
                return false;

            if (DateInfracted.AddSeconds((double)BanDuration) > DateTime.Now)
                return true;
            else
                return false;
        }

        public bool IsActiveWarning()
        {
            if (BanDuration != null)
                return false;

            if (DismissDate != null && DismissDate < DateTime.Now)
                return false;
            else
                return true;
        }
    }
}
