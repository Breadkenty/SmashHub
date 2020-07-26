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
    public class ComboVotesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ComboVotesController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost("{id}/{upOrDown}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> PostComboVote(int id, string upOrDown)
        {
            var voteExists = await _context.ComboVotes.AnyAsync(comboVote => comboVote.UserId == GetCurrentUserId() && comboVote.ComboId == id && comboVote.upOrDown == upOrDown);

            if (voteExists)
            {
                _context.ComboVotes.Remove(_context.ComboVotes.Single(comboVote => comboVote.UserId == GetCurrentUserId() && comboVote.ComboId == id && comboVote.upOrDown != upOrDown));
            }

            var comboVote = new ComboVote
            {
                ComboId = id,
                UserId = GetCurrentUserId(),
                upOrDown = upOrDown
            };
            await _context.ComboVotes.AddAsync(comboVote);

            var combo = await _context.Combos.FindAsync(id);

            if (combo == null)
            {
                return NotFound();
            }

            switch (upOrDown)
            {
                case "upvote":
                    combo.VoteUp();
                    break;
                case "downvote":
                    combo.VoteDown();
                    break;
                default:
                    return BadRequest();
            }

            _context.Entry(combo).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private int GetCurrentUserId()
        {
            return int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);
        }
    }
}
