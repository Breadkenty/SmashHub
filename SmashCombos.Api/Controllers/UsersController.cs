using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmashCombos.Core.Cqrs.Users.ForgotPassword;
using SmashCombos.Core.Cqrs.Users.GetUser;
using SmashCombos.Core.Cqrs.Users.GetUsers;
using SmashCombos.Core.Cqrs.Users.ResetPassword;
using SmashCombos.Core.Cqrs.Users.PostUser;
using SmashCombos.Core.Cqrs.Users.UnbanUser;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmashCombos.Controllers
{
    // All of these routes will be at the base URL:     /api/Users
    // That is what "api/[controller]" means below. It uses the name of the controller
    // in this case UsersController to determine the URL
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<GetUsersResponse>>> GetUsers() => Ok(await _mediator.Send(new GetUsersRequest { CurrentUserId = GetCurrentUserId() }));

        [HttpGet("unauth")]
        public async Task<ActionResult<IEnumerable<GetUsersResponse>>> GetUsersUnauthorized() => Ok(await _mediator.Send(new GetUsersRequest()));

        [HttpGet("{displayName}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<GetUserResponse>> GetUser([FromRoute] string displayName) => Ok(await _mediator.Send(new GetUserRequest { DisplayName = displayName, CurrentUserId = GetCurrentUserId() }));

        [HttpGet("unauth/{displayName}")]
        public async Task<ActionResult<GetUserResponse>> GetUserUnauthorized([FromRoute] string displayName) => Ok(await _mediator.Send(new GetUserRequest { DisplayName = displayName }));

        [HttpPost]
        public async Task<ActionResult<PostUserResponse>> PostUser([FromBody] PostUserRequest request)
        {
            var response = await _mediator.Send(request);

            if (response != null)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            request.NewPasswordUrl = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Url.Content("/resetpassword"));

            var response = await _mediator.Send(request);

            if (response != null)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpPost("resetpassword/{id}/{token}")]
        public async Task<IActionResult> ResetPassword([FromRoute] int id, [FromRoute] string token, [FromBody] string resetPassword)
        {
            var response = await _mediator.Send(new ResetPasswordRequest { UserId = id, Token = token, ResetPassword = resetPassword });

            if (response != null)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpPut("unban/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<UnbanUserResponse>> UnbanUser([FromRoute] int id)
        {
            var response = await _mediator.Send(new UnbanUserRequest { UserId = id, CurrentUserId = GetCurrentUserId() });

            if (response != null)
                return Ok(response);
            else
                return StatusCode(500);
        }

        private int GetCurrentUserId()
        {
            return int.Parse(User.Claims.SingleOrDefault(claim => claim.Type == "Id").Value);
        }
    }
}
