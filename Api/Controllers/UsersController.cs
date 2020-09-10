using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smash_Combos.Core.Cqrs.Users.ForgotPassword;
using Smash_Combos.Core.Cqrs.Users.GetUser;
using Smash_Combos.Core.Cqrs.Users.GetUsers;
using Smash_Combos.Core.Cqrs.Users.NewPassword;
using Smash_Combos.Core.Cqrs.Users.PostUser;
using Smash_Combos.Core.Cqrs.Users.UnbanUser;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smash_Combos.Controllers
{
    // All of these routes will be at the base URL:     /api/Users
    // That is what "api/[controller]" means below. It uses the name of the controller
    // in this case UsersController to determine the URL
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _mediator.Send(new GetUsersRequest());

            switch (response.ResponseStatus)
            {
                case Core.Cqrs.ResponseStatus.Ok:
                    return Ok(response.Data);
                case Core.Cqrs.ResponseStatus.NotFound:
                    return NotFound(new { errors = new List<string>() { response.ResponseMessage } });
                case Core.Cqrs.ResponseStatus.BadRequest:
                    return BadRequest(new { errors = new List<string>() { response.ResponseMessage } });
                case Core.Cqrs.ResponseStatus.NotAuthorized:
                    return Forbid();
                default:
                    return StatusCode(500, new { errors = new List<string>() { response.ResponseMessage } });
            }
        }

        [HttpGet("{displayName}")]
        public async Task<IActionResult> GetUser([FromRoute] string displayName)
        {
            var response = await _mediator.Send(new GetUserRequest { DisplayName = displayName });

            switch (response.ResponseStatus)
            {
                case Core.Cqrs.ResponseStatus.Ok:
                    return Ok(response.Data);
                case Core.Cqrs.ResponseStatus.NotFound:
                    return NotFound(new { errors = new List<string>() { response.ResponseMessage } });
                case Core.Cqrs.ResponseStatus.BadRequest:
                    return BadRequest(new { errors = new List<string>() { response.ResponseMessage } });
                case Core.Cqrs.ResponseStatus.NotAuthorized:
                    return Forbid();
                default:
                    return StatusCode(500, new { errors = new List<string>() { response.ResponseMessage } });
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] PostUserRequest request)
        {
            var response = await _mediator.Send(request);

            switch (response.ResponseStatus)
            {
                case Core.Cqrs.ResponseStatus.Ok:
                    return CreatedAtAction("GetUser", new { id = response.Data.Id }, response.Data);
                case Core.Cqrs.ResponseStatus.NotFound:
                    return NotFound(new { errors = new List<string>() { response.ResponseMessage } });
                case Core.Cqrs.ResponseStatus.BadRequest:
                    return BadRequest(new { errors = new List<string>() { response.ResponseMessage } });
                case Core.Cqrs.ResponseStatus.NotAuthorized:
                    return Forbid();
                default:
                    return StatusCode(500, new { errors = new List<string>() { response.ResponseMessage } });
            }
        }

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            request.NewPasswordUrl = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Url.Content("/newpassword"));

            var response = await _mediator.Send(request);

            if (response != null)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpPost("newpassword/{id}/{token}")]
        public async Task<IActionResult> NewPassword([FromRoute] int id, [FromRoute] string token)
        {
            var response = await _mediator.Send(new NewPasswordRequest { Userid = id, Token = token });

            if (response != null)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpPut("unban/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UnbanUser([FromRoute] int id)
        {
            var response = await _mediator.Send(new UnbanUserRequest { UserId = id, ModeratorId = GetCurrentUserId() });

            switch (response.ResponseStatus)
            {
                case Core.Cqrs.ResponseStatus.Ok:
                    return Ok(response.Data);
                case Core.Cqrs.ResponseStatus.NotFound:
                    return NotFound(new { errors = new List<string>() { response.ResponseMessage } });
                case Core.Cqrs.ResponseStatus.BadRequest:
                    return BadRequest(new { errors = new List<string>() { response.ResponseMessage } });
                case Core.Cqrs.ResponseStatus.NotAuthorized:
                    return Forbid();
                default:
                    return StatusCode(500, new { errors = new List<string>() { response.ResponseMessage } });
            }
        }

        private int GetCurrentUserId()
        {
            // Get the User Id from the claim and then parse it as an integer.
            return int.Parse(User.Claims.SingleOrDefault(claim => claim.Type == "Id").Value);
        }
    }
}
