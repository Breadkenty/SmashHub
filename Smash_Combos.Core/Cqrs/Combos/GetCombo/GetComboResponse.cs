﻿using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;

namespace Smash_Combos.Core.Cqrs.Combos.GetCombo
{
    public class GetComboResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CharacterId { get; set; }
        public DateTime DatePosted { get; set; }
        public string Title { get; set; }
        public string VideoId { get; set; }
        public int VideoStartTime { get; set; }
        public int VideoEndTime { get; set; }
        public string ComboInput { get; set; }
        public bool TrueCombo { get; set; }
        public string Difficulty { get; set; }
        public int Damage { get; set; }
        public string Notes { get; set; }
        public List<Comment> Comments { get; set; }
        public int NetVote { get; set; }
    }
}
