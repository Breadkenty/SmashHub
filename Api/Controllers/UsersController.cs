using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smash_Combos.Core.Cqrs.Users.GetUser;
using Smash_Combos.Core.Cqrs.Users.GetUsers;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<GetUsersResponse>>> GetUsers() => Ok(await _mediator.Send(new GetUsersRequest { CurrentUserId = GetCurrentUserId() }));

        [HttpGet("{displayName}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<GetUserResponse>> GetUser([FromRoute] string displayName) => Ok(await _mediator.Send(new GetUserRequest { DisplayName = displayName, CurrentUserId = GetCurrentUserId() }));

        [HttpPost]
        public async Task<ActionResult<PostUserResponse>> PostUser([FromBody] PostUserRequest request)
        {
            var response = await _mediator.Send(request);

            if (response != null)
                return CreatedAtAction("GetUser", new { id = response.Id }, response);
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
