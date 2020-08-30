using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Domain.Models;
using Smash_Combos.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Smash_Combos.Core.Cqrs.Users.GetUser;
using Smash_Combos.Core.Cqrs.Users.GetUsers;
using Smash_Combos.Core.Cqrs.Users.PostUser;

namespace Smash_Combos.Controllers
{
    // All of these routes will be at the base URL:     /api/Users
    // That is what "api/[controller]" means below. It uses the name of the controller
    // in this case UsersController to determine the URL
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // This is the variable you use to have access to your database
        private readonly IDbContext _context;
        private readonly IMediator _mediator;

        // Constructor that recives a reference to your database context
        // and stores it in _context for you to use in your API methods
        public UsersController(IDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var response = await _mediator.Send(new GetUsersRequest());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserResponse>> GetUser([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetUserRequest { UserId = id });

            if (response == null)
            {
                // Return a `404` response to the client indicating we could not find a combo with this id
                return NotFound();
            }

            //  Return the combo as a JSON object.
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] User user)
        {
            var response = await _mediator.Send(new PostUserRequest { User = user });

            if (response.DisplayNameAlreadyExists)
            {
                var httpResponse = new
                {
                    status = 400,
                    errors = new List<string>() { "There's already an account with this display name" }
                };
                return BadRequest(httpResponse);
            }

            if (response.EmailAlreadyExists)
            {
                var httpResponse = new
                {
                    status = 400,
                    errors = new List<string>() { "There's already an account with this email" }
                };
                return BadRequest(httpResponse);
            }

            if (response.PasswordDoesntMeetCriteria)
            {
                var httpResponse = new
                {
                    status = 400,
                    errors = new List<string>() { "Password must be at least 8 characters" }
                };
                return BadRequest(httpResponse);
            }

            if(response.User == null)
            {
                var httpResponse = new
                {
                    status = 500,
                    errors = new List<string>() { "Internal server error" }
                };
                return StatusCode(500, httpResponse);
            }

            // Return a response that indicates the object was created (status code `201`) and some additional
            // headers with details of the newly created object.
            return CreatedAtAction("GetUser", new { id = user.Id }, response.User);
        }
    }
}
