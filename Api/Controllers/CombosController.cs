using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
using System.Net.Http;
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
        public async Task<ActionResult<IEnumerable<Core.Cqrs.Combos.GetCombo.ComboDto>>> GetCombos()
        {
            var response = await _mediator.Send(new GetCombosRequest());

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

        // GET: api/Combos/5
        //
        // Fetches and returns a specific combo by finding it by id. The id is specified in the
        // URL. In the sample URL above it is the `5`.  The "{id}" in the [HttpGet("{id}")] is what tells dotnet
        // to grab the id from the URL. It is then made available to us as the `id` argument to the method.
        //
        [HttpGet("{id}")]
        public async Task<ActionResult<Core.Cqrs.Combos.GetCombo.ComboDto>> GetCombo([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetComboRequest { ComboId = id });

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
        public async Task<IActionResult> PutCombo([FromRoute] int id, [FromBody] PutComboRequest putComboRequest)
        {
            if (id != putComboRequest.Id) // If the ID in the URL does not match the ID in the supplied request body, return a bad request
                return BadRequest();
            var response = await _mediator.Send(putComboRequest);

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
        public async Task<ActionResult<PostComboResponse>> PostCombo([FromBody] PostComboRequest request)
        {
            request.UserId = GetCurrentUserId();

            var response = await _mediator.Send(request);

            switch (response.ResponseStatus)
            {
                case Core.Cqrs.ResponseStatus.Ok:
                    return CreatedAtAction("GetCombo", new { id = response.Data.Id }, response.Data);
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

        // DELETE: api/Combos/5
        //
        // Deletes an individual combo with the requested id. The id is specified in the URL
        // In the sample URL above it is the `5`. The "{id} in the [HttpDelete("{id}")] is what tells dotnet
        // to grab the id from the URL. It is then made available to us as the `id` argument to the method.
        //
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteCombo([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteComboRequest { ComboId = id, UserId = GetCurrentUserId() });

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
            return int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);
        }
    }
}
