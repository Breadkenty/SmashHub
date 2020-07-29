using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Smash_Combos.Models;


namespace Smash_Combos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        readonly protected string JWT_KEY;

        public SessionsController(DatabaseContext context, IConfiguration config)
        {
            _context = context;
            JWT_KEY = config["JWT_KEY"];
        }

        public class LoginUser
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginUser loginUser)
        {
            var foundUser = await _context.Users.FirstOrDefaultAsync(user => user.Email.ToLower() == loginUser.Email.ToLower());
            if (foundUser != null && foundUser.IsValidPassword(loginUser.Password))
            {
                // create a custom response
                var response = new
                {
                    // This is the login token
                    token = new TokenGenerator(JWT_KEY).TokenFor(foundUser),
                    // The is the user details
                    user = foundUser
                };
                return Ok(response);
            }
            if (foundUser != null && !foundUser.IsValidPassword(loginUser.Password))
            {
                var response = new
                {
                    status = 400,
                    errors = new List<string>() { $"Invalid password" }
                };
                // Return our error with the custom response
                return BadRequest(response);
            }
            else
            {
                // Make a custom error response
                var response = new
                {
                    status = 400,
                    errors = new List<string>() { $"User does not exist" }
                };
                // Return our error with the custom response
                return BadRequest(response);
            }
        }

    }
}
