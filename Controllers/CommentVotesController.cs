using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Models;

namespace Smash_Combos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentVotesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CommentVotesController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost("{id}/{upOrDown}")]
        public async Task<IActionResult> PostCommentVote(int id, string upOrDown)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            switch (upOrDown)
            {
                case "upvote":
                    comment.VoteUp();
                    break;
                case "downvote":
                    comment.VoteDown();
                    break;
                default:
                    return BadRequest();
            }

            _context.Entry(comment).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
