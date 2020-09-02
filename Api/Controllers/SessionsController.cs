using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Smash_Combos.Core.Cqrs.Sessions.Login;
using Smash_Combos.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Smash_Combos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SessionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            var response = await _mediator.Send(loginRequest);
            if(response.User != null && response.Token != null)
                return Ok(response);

            if (response.User != null && !response.PasswordIsValid)
            {
                var responseObject = new
                {
                    status = 400,
                    errors = new List<string>() { response.ResponseMessage }
                };
                // Return our error with the custom response
                return BadRequest(responseObject);
            }
            else
            {
                // Make a custom error response
                var responseObject = new
                {
                    status = 400,
                    errors = new List<string>() { response.ResponseMessage }
                };
                // Return our error with the custom response
                return BadRequest(responseObject);
            }
        }
    }
}
