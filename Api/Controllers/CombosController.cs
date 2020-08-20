using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Cqrs.Combos.DeleteCombo;
using Smash_Combos.Core.Cqrs.Combos.GetCombo;
using Smash_Combos.Core.Cqrs.Combos.GetCombos;
using Smash_Combos.Core.Cqrs.Combos.PostCombo;
using Smash_Combos.Core.Cqrs.Combos.PutCombo;
using Smash_Combos.Core.Services;
using Smash_Combos.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Controllers
{
    // All of these routes will be at the base URL:     /api/Combos
    // That is what "api/[controller]" means below. It uses the name of the controller
    // in this case CombosController to determine the URL
    [Route("api/[controller]")]
    [ApiController]
    public class CombosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CombosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Combos
        //
        // Returns a list of all your Combos
        //
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCombosResponse>>> GetCombos()
        {
            var response = await _mediator.Send(new GetCombosRequest());
            return Ok(response);
        }

        // GET: api/Combos/5
        //
        // Fetches and returns a specific combo by finding it by id. The id is specified in the
        // URL. In the sample URL above it is the `5`.  The "{id}" in the [HttpGet("{id}")] is what tells dotnet
        // to grab the id from the URL. It is then made available to us as the `id` argument to the method.
        //
        [HttpGet("{id}")]
        public async Task<ActionResult<GetComboResponse>> GetCombo(int id)
        {
            var response = await _mediator.Send(new GetComboRequest { ComboID = id });

            if (response == null)
                return NotFound(); // Return a `404` response to the client indicating we could not find a combo with this id

            return Ok(response); // Return the combo as a JSON object.
        }

        // PUT: api/Combos/5
        //
        // Update an individual combo with the requested id. The id is specified in the URL
        // In the sample URL above it is the `5`. The "{id} in the [HttpPut("{id}")] is what tells dotnet
        // to grab the id from the URL. It is then made available to us as the `id` argument to the method.
        //
        // In addition the `body` of the request is parsed and then made available to us as a Combo
        // variable named combo. The controller matches the keys of the JSON object the client
        // supplies to the names of the attributes of our Combo POCO class. This represents the
        // new values for the record.
        //
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutCombo(int id, Combo combo)
        {
            if (id != combo.Id) // If the ID in the URL does not match the ID in the supplied request body, return a bad request
                return BadRequest();

            try
            {
                var response = await _mediator.Send(new PutComboRequest { Combo = combo, ComboId = id, UserId = combo.UserId });

                if (response.Success)
                    return NoContent(); // Return NoContent to indicate the update was done.
                else if (!response.ComboFound)
                    return NotFound();
                else
                    return StatusCode(500); // The combo was found, but couldn't be updated -> something went wrong. How should we handle this?
            }
            catch (DbUpdateConcurrencyException)
            {
                throw; // Should we throw the exception here or deal with it otherwise?
            }
        }

        // POST: api/Combos
        //
        // Creates a new combo in the database.
        //
        // The `body` of the request is parsed and then made available to us as a Combo
        // variable named combo. The controller matches the keys of the JSON object the client
        // supplies to the names of the attributes of our Combo POCO class. This represents the
        // new values for the record.
        //
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PostComboResponse>> PostCombo(Combo combo)
        {
            var response = await _mediator.Send(new PostComboRequest { Combo = combo, UserId = GetCurrentUserId() });

            // Return a response that indicates the object was created (status code `201`) and some additional headers with details of the newly created object.
            return CreatedAtAction("GetCombo", new { id = response.Id }, response);
        }

        // DELETE: api/Combos/5
        //
        // Deletes an individual combo with the requested id. The id is specified in the URL
        // In the sample URL above it is the `5`. The "{id} in the [HttpDelete("{id}")] is what tells dotnet
        // to grab the id from the URL. It is then made available to us as the `id` argument to the method.
        //
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteCombo(int id)
        {
            var response = await _mediator.Send(new DeleteComboRequest { ComboId = id, UserId = GetCurrentUserId() });

            if (response.Combo == null) // There wasn't a combo with that id so return a `404` not found
                return NotFound();

            return Ok(response.Combo); // Send back a copy of the deleted data.
        }

        private int GetCurrentUserId()
        {
            // Get the User Id from the claim and then parse it as an integer.
            return int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);
        }
    }
}
