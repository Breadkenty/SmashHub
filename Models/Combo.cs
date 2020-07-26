using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Smash_Combos.Models
{
    public class Combo
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public int CharacterId { get; set; }

        public User User { get; set; }

        public DateTime DatePosted { get; private set; } = DateTime.Now;

        [Required]
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

        public string Notes { get; set; }

        public List<Comment> Comments { get; private set; }

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