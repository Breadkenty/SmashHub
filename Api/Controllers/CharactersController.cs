using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Domain.Models;
using Smash_Combos.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Smash_Combos.Core.Cqrs.Characters.GetCharacters;
using Smash_Combos.Core.Cqrs.Characters.GetCharacter;
using Smash_Combos.Core.Cqrs.Characters;
using Smash_Combos.Core.Cqrs.Characters.PutCharacter;
using Smash_Combos.Core.Cqrs.Characters.PostCharacter;
using Smash_Combos.Core.Cqrs.Characters.DeleteCharacter;
using Smash_Combos.Core.Cqrs;

namespace Smash_Combos.Controllers
{
    // All of these routes will be at the base URL:     /api/Characters
    // That is what "api/[controller]" means below. It uses the name of the controller
    // in this case CharactersController to determine the URL
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly IMediator _mediator;

        // Constructor that recives a reference to your database context
        // and stores it in _context for you to use in your API methods
        public CharactersController(IDbContext context, IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Characters
        //
        // Returns a list of all your Characters
        //
        [HttpGet]
        public async Task<IActionResult> GetCharacters([FromQuery] string filter)
        {
            var response = await _mediator.Send(new GetCharactersRequest { Filter = filter });

            switch (response.ResponseStatus)
            {
                case ResponseStatus.Ok:
                    return Ok(response.Data);
                case ResponseStatus.NotFound:
                    return NotFound(new { errors = new List<string>() { response.ResponseMessage } });
                case ResponseStatus.BadRequest:
                    return BadRequest(new { errors = new List<string>() { response.ResponseMessage } });
                case ResponseStatus.NotAuthorized:
                    return Forbid();
                default:
                    return StatusCode(500, new { errors = new List<string>() { response.ResponseMessage } });
            }
        }

        // GET: api/Characters/5
        //
        // Fetches and returns a specific character by finding it by id. The id is specified in the
        // URL. In the sample URL above it is the `5`.  The "{id}" in the [HttpGet("{id}")] is what tells dotnet
        // to grab the id from the URL. It is then made available to us as the `id` argument to the method.
        //
        [HttpGet("{variableName}")]
        public async Task<IActionResult> GetCharacter([FromRoute] string variableName)
        {
            var response = await _mediator.Send(new GetCharacterRequest { VariableName = variableName }); ;
            
            switch (response.ResponseStatus)
            {
                case ResponseStatus.Ok:
                    return Ok(response.Data);
                case ResponseStatus.NotFound:
                    return NotFound(new { errors = new List<string>() { response.ResponseMessage } });
                case ResponseStatus.BadRequest:
                    return BadRequest(new { errors = new List<string>() { response.ResponseMessage } });
                case ResponseStatus.NotAuthorized:
                    return Forbid();
                default:
                    return StatusCode(500, new { errors = new List<string>() { response.ResponseMessage } });
            }
        }

        // PUT: api/Characters/5
        //
        // Update an individual character with the requested id. The id is specified in the URL
        // In the sample URL above it is the `5`. The "{id} in the [HttpPut("{id}")] is what tells dotnet
        // to grab the id from the URL. It is then made available to us as the `id` argument to the method.
        //
        // In addition the `body` of the request is parsed and then made available to us as a Character
        // variable named character. The controller matches the keys of the JSON object the client
        // supplies to the names of the attributes of our Character POCO class. This represents the
        // new values for the record.
        //
        [HttpPut("{variableName}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutCharacter([FromRoute] string variableName, PutCharacterRequest request)
        {
            if (request.VariableName != variableName)
                return BadRequest();

            request.CurrentUserId = GetCurrentUserId();

            var response = await _mediator.Send(request); ;

            switch (response.ResponseStatus)
            {
                case ResponseStatus.Ok:
                    return Ok();
                case ResponseStatus.NotFound:
                    return NotFound(new { errors = new List<string>() { response.ResponseMessage } });
                case ResponseStatus.BadRequest:
                    return BadRequest(new { errors = new List<string>() { response.ResponseMessage } });
                case ResponseStatus.NotAuthorized:
                    return Forbid();
                default:
                    return StatusCode(500, new { errors = new List<string>() { response.ResponseMessage } });
            }
        }

        // POST: api/Characters
        //
        // Creates a new character in the database.
        //
        // The `body` of the request is parsed and then made available to us as a Character
        // variable named character. The controller matches the keys of the JSON object the client
        // supplies to the names of the attributes of our Character POCO class. This represents the
        // new values for the record.
        //
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PostCharacter([FromBody] PostCharacterRequest request)
        {            
            request.CurrentUserId = GetCurrentUserId();

            var response = await _mediator.Send(request); ;

            switch (response.ResponseStatus)
            {
                case ResponseStatus.Ok:
                    return CreatedAtAction("GetCharacter", new { id = response.Data.VariableName }, response.Data);
                case ResponseStatus.NotFound:
                    return NotFound(new { errors = new List<string>() { response.ResponseMessage } });
                case ResponseStatus.BadRequest:
                    return BadRequest(new { errors = new List<string>() { response.ResponseMessage } });
                case ResponseStatus.NotAuthorized:
                    return Forbid();
                default:
                    return StatusCode(500, new { errors = new List<string>() { response.ResponseMessage } });
            }
        }

        // DELETE: api/Characters/5
        //
        // Deletes an individual character with the requested id. The id is specified in the URL
        // In the sample URL above it is the `5`. The "{id} in the [HttpDelete("{id}")] is what tells dotnet
        // to grab the id from the URL. It is then made available to us as the `id` argument to the method.
        //
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> DeleteCharacter([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteCharacterRequest { CharacterId = id, CurrentUserId = GetCurrentUserId() });

            switch (response.ResponseStatus)
            {
                case ResponseStatus.Ok:
                    return Ok();
                case ResponseStatus.NotFound:
                    return NotFound(new { errors = new List<string>() { response.ResponseMessage } });
                case ResponseStatus.BadRequest:
                    return BadRequest(new { errors = new List<string>() { response.ResponseMessage } });
                case ResponseStatus.NotAuthorized:
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
