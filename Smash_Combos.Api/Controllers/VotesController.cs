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
using Smash_Combos.Core.Cqrs.Votes.GetCommentVoteForUser;
using Smash_Combos.Core.Cqrs.Votes.GetComboVoteForUser;

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
            var isUpVote = upOrDown == "upvote";

            var result = await _mediator.Send(new PostComboVoteRequest { ComboId = id, CurrentUserId = GetCurrentUserId(), IsUpVote = isUpVote });

            if (result != null)
                return NoContent();
            else
                return StatusCode(500);
        }

        [HttpGet("combo/{comboId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<GetComboVoteForUserResponse>> GetComboVoteForCurrentUser([FromRoute] int comboId)
        {
            var response = await _mediator.Send(new GetComboVoteForUserRequest { ComboId = comboId, UserId = GetCurrentUserId() });

            if (response != null)
                return response;
            else
                return StatusCode(500);
        }

        [HttpPost("comment/{commentId}/{upOrDown}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PostCommentVote([FromRoute] int commentId, [FromRoute] string upOrDown)
        {
            var isUpVote = upOrDown == "upvote";

            var result = await _mediator.Send(new PostCommentVoteRequest { CommentId = commentId, CurrentUserId = GetCurrentUserId(), IsUpVote = isUpVote });

            if (result != null)
                return NoContent();
            else
                return StatusCode(500);
        }

        [HttpGet("comment/{commentId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<GetCommentVoteForUserResponse>> GetCommentVoteForCurrentUser([FromRoute] int commentId)
        {
            var response = await _mediator.Send(new GetCommentVoteForUserRequest { CommentId = commentId, UserId = GetCurrentUserId() });

            if (response != null)
                return response;
            else
                return StatusCode(500);
        }

        private int GetCurrentUserId()
        {
            return int.Parse(User.Claims.SingleOrDefault(claim => claim.Type == "Id").Value);
        }
    }
}
