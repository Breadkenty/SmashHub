using MediatR;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmashCombos.Core.Cqrs.Combos.PostCombo
{
    public class PostComboRequest : IRequest<PostComboResponse>
    {
        [Required]
        public int CharacterId { get; set; }
        [Required]
        public int CurrentUserId { get; set; }
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
    }
}
