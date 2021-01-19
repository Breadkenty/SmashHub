using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmashCombos.Core.Cqrs.Sessions.Login;
using SmashCombos.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SmashCombos.Controllers
{
    [Route("[controller]")]
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
            if (response.User != null && response.Token != null)
                return Ok(response);
            else
                return StatusCode(500);
        }
    }
}
