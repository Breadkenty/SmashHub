using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> PostCommentVote(int id, string upOrDown)
        {
            var voteExists = await _context.CommentVotes.AnyAsync(commentVote => commentVote.UserId == GetCurrentUserId() && commentVote.CommentId == id && commentVote.upOrDown == upOrDown);

            if (voteExists)
            {
                _context.CommentVotes.Remove(_context.CommentVotes.Single(commentVote => commentVote.UserId == GetCurrentUserId() && commentVote.CommentId == id && commentVote.upOrDown != upOrDown));
            }

            var commentVote = new CommentVote
            {
                CommentId = id,
                UserId = GetCurrentUserId(),
                upOrDown = upOrDown
            };
            await _context.CommentVotes.AddAsync(commentVote);

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
        private int GetCurrentUserId()
        {
            return int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);
        }
    }
}
