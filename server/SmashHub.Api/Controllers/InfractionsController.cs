using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmashHub.Core.Cqrs.Infractions.DeleteInfraction;
using SmashHub.Core.Cqrs.Infractions.DismissInfraction;
using SmashHub.Core.Cqrs.Infractions.GetInfraction;
using SmashHub.Core.Cqrs.Infractions.GetInfractions;
using SmashHub.Core.Cqrs.Infractions.GetInfractionsByUser;
using SmashHub.Core.Cqrs.Infractions.PostInfraction;
using SmashHub.Core.Cqrs.Infractions.PutInfraction;
using SmashHub.Domain.Models;

namespace SmashHub.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InfractionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InfractionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<InfractionsController>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<GetInfractionsResponse>>> GetInfractions() => Ok(await _mediator.Send(new GetInfractionsRequest { CurrentUserId = GetCurrentUserId() }));

        // GET api/<InfractionsController>/5
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<GetInfractionResponse>> GetInfraction([FromRoute] int id) => Ok(await _mediator.Send(new GetInfractionRequest { InfractionId = id, CurrentUserId = GetCurrentUserId() }));

        // GET api/<InfractionsController>/user/Username
        [HttpGet("user/{userName}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<GetInfractionsByUserResponse>>> GetInfractionsByUser([FromRoute] string userName) => Ok(await _mediator.Send(new GetInfractionsByUserRequest { DisplayName = userName, CurrentUserId = GetCurrentUserId() }));

        // POST api/<InfractionsController>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PostInfraction([FromBody] PostInfractionRequest request)
        {
            request.CurrentUserId = GetCurrentUserId();

            var response = await _mediator.Send(request);

            if (response != null)
                return CreatedAtAction("GetInfraction", new { id = response.Id }, response);
            else
                return StatusCode(500);
        }

        // PUT api/<InfractionsController>/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutInfraction([FromRoute] int id, [FromBody] PutInfractionRequest request)
        {
            if (id != request.InfractionId) // If the ID in the URL does not match the ID in the supplied request body, return a bad request
                return BadRequest(new StatusCodeProblemDetails(400) { Detail = "Id in URL and Infraction don't match" });

            request.CurrentUserId = GetCurrentUserId();

            var response = await _mediator.Send(request);

            if (response != null)
                return Ok();
            else
                return StatusCode(500);
        }

        // PUT api/<InfractionsController>/5
        [HttpPut("dismiss/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DismissInfraction([FromRoute] int id, [FromBody] DismissInfractionRequest request)
        {
            if (id != request.InfractionId) // If the ID in the URL does not match the ID in the supplied request body, return a bad request
                return BadRequest(new StatusCodeProblemDetails(400) { Detail = "Id in URL and Infraction don't match" });

            request.CurrentUserId = GetCurrentUserId();

            var response = await _mediator.Send(request);

            if (response != null)
                return Ok();
            else
                return StatusCode(500);
        }

        // DELETE api/<InfractionsController>/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteInfraction(int id)
        {
            var response = await _mediator.Send(new DeleteInfractionRequest { InfractionId = id, CurrentUserId = GetCurrentUserId() });

            if (response != null)
                return Ok();
            else
                return StatusCode(500);
        }

        private int GetCurrentUserId()
        {
            // Get the User Id from the claim and then parse it as an integer.
            return int.Parse(User.Claims.SingleOrDefault(claim => claim.Type == "Id").Value);
        }
    }
}
