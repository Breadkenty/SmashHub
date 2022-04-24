namespace SmashHub.Domain.Models
{
    public class ComboVote
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Combo Combo { get; set; }
        public bool IsUpvote { get; set; }
    }
}