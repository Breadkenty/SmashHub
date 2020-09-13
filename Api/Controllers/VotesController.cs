using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Domain.Models;
using Smash_Combos.Core.Services;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Smash_Combos.Core.Cqrs.Votes.PostComboVote;
using Smash_Combos.Core.Cqrs.Votes.PostCommentVote;

namespace Smash_Combos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("combo/{id}/{upOrDown}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PostComboVote(int id, string upOrDown)
        {
            var result = await _mediator.Send(new PostComboVoteRequest { ComboId = id, CurrentUserId = GetCurrentUserId(), UpOrDown = upOrDown });

            if (result != null)
                return NoContent();
            else
                return StatusCode(500);
        }

        [HttpPost("comment/{id}/{upOrDown}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PostCommentVote(int id, string upOrDown)
        {
            var result = await _mediator.Send(new PostCommentVoteRequest { CommentId = id, CurrentUserId = GetCurrentUserId(), UpOrDown = upOrDown });

            if (result != null)
                return NoContent();
            else
                return StatusCode(500);
        }

        private int GetCurrentUserId()
        {
            return int.Parse(User.Claims.SingleOrDefault(claim => claim.Type == "Id").Value);
        }
    }
}
