using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmashHub.Core.Cqrs.Sessions.Login;
using SmashHub.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SmashHub.Controllers
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
