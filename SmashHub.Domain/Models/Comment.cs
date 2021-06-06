using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmashHub.Domain.Models
{
    public class Comment
    {
        public Comment()
        {
            this.DatePosted = DateTime.Now;
        }
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public Combo Combo { get; set; }
        public DateTime DatePosted { get; private set; }

        [Required]
        public string Body { get; set; }
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