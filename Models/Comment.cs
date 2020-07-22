using System.ComponentModel.DataAnnotations;

namespace Smash_Combos.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int ComboId { get; set; }

        [Required]
        public string Body { get; set; }
        public int NetVote { get; set; } = 0;

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