using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmashCombos.Domain.Models
{
    public class Report
    {

        public Report()
        {
            this.DateReported = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        public User Reporter { get; set; }

        public Comment Comment { get; set; }

        public Combo Combo { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime DateReported { get; private set; }

        public bool Dismiss { get; set; }
    }
}
