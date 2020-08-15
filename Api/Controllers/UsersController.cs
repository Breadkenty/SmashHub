using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Domain.Models;
using Smash_Combos.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        // This is the variable you use to have access to your database
        private readonly IDbContext _context;

        // Constructor that recives a reference to your database context
        // and stores it in _context for you to use in your API methods
        public UsersController(IDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.Where(user => user.Id == id).FirstOrDefaultAsync();

            if (user == null)
            {
                // Return a `404` response to the client indicating we could not find a combo with this id
                return NotFound();
            }

            //  Return the combo as a JSON object.
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var emailExists = _context.Users.Any(existingUser => existingUser.Email.ToLower() == user.Email.ToLower());
            var displayNameExists = _context.Users.Any(existingUser => existingUser.DisplayName.ToLower() == user.DisplayName.ToLower());

            if (displayNameExists)
            {
                var response = new
                {
                    status = 400,
                    errors = new List<string>() { "There's already an account with this display name" }
                };

                return BadRequest(response);
            }

            if (emailExists)
            {
                var response = new
                {
                    status = 400,
                    errors = new List<string>() { "There's already an account with this email" }
                };

                return BadRequest(response);
            }

            if (!user.PasswordMeetsCriteria)
            {
                var response = new
                {
                    status = 400,
                    errors = new List<string>() { "Password must be at least 8 characters" }
                };

                return BadRequest(response);
            }


            // Indicate to the database context we want to add this new record
            _context.Users.Add(user);
            await _context.SaveChangesAsync(CancellationToken.None);

            // Return a response that indicates the object was created (status code `201`) and some additional
            // headers with details of the newly created object.
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // Private helper method that looks up an existing user by the supplied id
        private bool UserExists(int id)
        {
            return _context.Users.Any(user => user.Id == id);
        }
    }
}
