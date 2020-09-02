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
        public async Task<ActionResult<IEnumerable<GetInfractionsResponse>>> GetInfractions()
        {
            var response = await _mediator.Send(new GetInfractionsRequest());
            return Ok(response);
        }

        // GET api/<InfractionsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetInfractionResponse>> GetInfraction([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetInfractionRequest { InfractionId = id });
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        // POST api/<InfractionsController>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PostInfractionResponse>> PostInfraction([FromBody] PostInfractionRequest postInfractionRequest)
        {
            var response = await _mediator.Send(postInfractionRequest);

            // Return a response that indicates the object was created (status code `201`) and some additional headers with details of the newly created object.
            return CreatedAtAction("GetInfraction", new { id = response.Id }, response);
        }

        // PUT api/<InfractionsController>/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PutInfractionResponse>> PutInfraction([FromRoute] int id, [FromBody] PutInfractionRequest putInfractionRequest)
        {
            if (id != putInfractionRequest.Id) // If the ID in the URL does not match the ID in the supplied request body, return a bad request
                return BadRequest();

            try
            {
                var response = await _mediator.Send(putInfractionRequest);

                if (response.Success)
                    return Ok(response.Infraction); // Return the updated infraction.
                else if (response.Infraction == null)
                    return NotFound();
                else
                    return StatusCode(500); // The infraction was found, but couldn't be updated -> something went wrong. How should we handle this?
            }
            catch (DbUpdateConcurrencyException)
            {
                throw; // Should we throw the exception here or deal with it otherwise?
            }
        }

        // DELETE api/<InfractionsController>/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> DeleteInfraction(int id)
        {
            var response = await _mediator.Send(new DeleteInfractionRequest { InfractionId = id, UserId = GetCurrentUserId() });

            if (response.Infraction == null) // There wasn't an infraction with that id so return a `404` not found
                return NotFound();

            return Ok(response.Infraction); // Send back a copy of the deleted data.
        }

        private int GetCurrentUserId()
        {
            // Get the User Id from the claim and then parse it as an integer.
            return int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);
        }
    }
}
