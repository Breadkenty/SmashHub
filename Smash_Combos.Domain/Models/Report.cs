using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Smash_Combos.Domain.Models
{
    public class Report
    {

        public Report()
        {
            this.DateReported = DateTime.Now;
        }
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ReporterId { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime DateReported { get; private set; }

        public bool Dismiss { get; set; }
    }
}
