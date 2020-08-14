using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Smash_Combos.Domain.Models
{
    public class Comment
    {
        public Comment()
        {
            this.DatePosted = DateTime.Now;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ComboId { get; set; }
        public DateTime DatePosted { get; private set; }

        [Required]
        public string Body { get; set; }
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