using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Cqrs.Infractions.DeleteInfraction;
using Smash_Combos.Core.Cqrs.Infractions.GetInfraction;
using Smash_Combos.Core.Cqrs.Infractions.GetInfractions;
using Smash_Combos.Core.Cqrs.Infractions.GetInfractionsByUser;
using Smash_Combos.Core.Cqrs.Infractions.PostInfraction;
using Smash_Combos.Core.Cqrs.Infractions.PutInfraction;
using Smash_Combos.Domain.Models;

namespace Smash_Combos.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> GetInfractions()
        {
            var response = await _mediator.Send(new GetInfractionsRequest { ModeratorId = GetCurrentUserId() });
            return Ok(response);
        }

        // GET api/<InfractionsController>/5
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetInfraction([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetInfractionRequest { InfractionId = id, ModeratorId = GetCurrentUserId() });

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

        // GET api/<InfractionsController>/user/Username
        [HttpGet("user/{userName}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetInfractionsByUser([FromRoute] string userName)
        {
            var response = await _mediator.Send(new GetInfractionsByUserRequest { DisplayName = userName, ModeratorId = GetCurrentUserId() });
            
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

        // POST api/<InfractionsController>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PostInfraction([FromBody] PostInfractionRequest request)
        {
            request.ModeratorId = GetCurrentUserId();

            var response = await _mediator.Send(request);

            switch (response.ResponseStatus)
            {
                case Core.Cqrs.ResponseStatus.Ok:
                    return CreatedAtAction("GetInfraction", new { id = response.Data.Id }, response);
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

        // PUT api/<InfractionsController>/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutInfraction([FromRoute] int id, [FromBody] PutInfractionRequest request)
        {
            if (id != request.Id) // If the ID in the URL does not match the ID in the supplied request body, return a bad request
                return BadRequest();

            request.ModeratorId = GetCurrentUserId();

            var response = await _mediator.Send(request);

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

        // DELETE api/<InfractionsController>/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteInfraction(int id)
        {
            var response = await _mediator.Send(new DeleteInfractionRequest { InfractionId = id, ModeratorId = GetCurrentUserId() });

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
