using System.Threading.Tasks;
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
        public async Task<IActionResult> PostComboVote(int id, string upOrDown)
        {
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
    }
}
