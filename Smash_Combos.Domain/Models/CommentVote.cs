namespace Smash_Combos.Domain.Models
{
    public class CommentVote
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public string upOrDown { get; set; }
    }
}