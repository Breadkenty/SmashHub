using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Domain.Models;
using Smash_Combos.Domain.Services;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComboVotesController : ControllerBase
    {
        private readonly IDbContext _context;

        public ComboVotesController(IDbContext context)
        {
            _context = context;
        }

        [HttpPost("{id}/{upOrDown}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> PostComboVote(int id, string upOrDown)
        {
            var combo = await _context.Combos.FindAsync(id);

            if (combo == null)
            {
                return NotFound();
            }

            var existingComboVote = await _context.ComboVotes.Where(comboVote => comboVote.UserId == GetCurrentUserId() && comboVote.ComboId == id).FirstOrDefaultAsync();

            if (existingComboVote != null)
            {
                if (existingComboVote.upOrDown == upOrDown)
                {
                    return NoContent();
                }

                switch (existingComboVote.upOrDown)
                {
                    case "downvote":
                        combo.VoteUp();
                        break;
                    case "upvote":
                        combo.VoteDown();
                        break;
                    default:
                        return BadRequest();
                }

                existingComboVote.upOrDown = upOrDown;
                _context.Entry(existingComboVote).State = EntityState.Modified;
                await _context.SaveChangesAsync(CancellationToken.None);
            }
            else
            {
                var comboVote = new ComboVote
                {
                    ComboId = id,
                    UserId = GetCurrentUserId(),
                    upOrDown = upOrDown
                };
                await _context.ComboVotes.AddAsync(comboVote);
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

            await _context.SaveChangesAsync(CancellationToken.None);

            return NoContent();
        }

        private int GetCurrentUserId()
        {
            return int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);
        }
    }
}
