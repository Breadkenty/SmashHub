namespace Smash_Combos.Domain.Models
{
    public class ComboVote
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ComboId { get; set; }
        public string upOrDown { get; set; }
    }
}