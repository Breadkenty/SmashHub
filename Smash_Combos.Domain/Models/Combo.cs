using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Smash_Combos.Domain.Models
{
    public class Combo
    {
        public int Id { get; set; }
        
        [Required]
        public Character Character { get; set; }

        [Required]
        public User User { get; set; }

        public DateTime DatePosted { get; private set; } = DateTime.Now;

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        public string VideoId { get; set; }

        [Required]
        public int VideoStartTime { get; set; }

        [Required]
        public int VideoEndTime { get; set; }

        [Required]
        public string ComboInput { get; set; }

        [Required]
        public bool TrueCombo { get; set; }

        [Required]
        public string Difficulty { get; set; }

        [Required]
        public int Damage { get; set; }

        [MaxLength(512)]
        public string Notes { get; set; }

        public List<Comment> Comments { get; private set; } = new List<Comment>();

        public List<Report> Reports { get; private set; } = new List<Report>();

        public int NetVote { get; private set; } = 0;
        public void VoteUp()
        {
            this.NetVote++;
        }
        public void VoteDown()
        {
            this.NetVote--;
        }


    }
}