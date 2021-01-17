namespace SmashCombos.Domain.Models
{
    public class CommentVote
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Comment Comment { get; set; }
        public bool IsUpvote { get; set; }
    }
}