using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smash_Combos.Core.Cqrs;
using Smash_Combos.Core.Cqrs.Characters.DeleteCharacter;
using Smash_Combos.Core.Cqrs.Characters.GetCharacter;
using Smash_Combos.Core.Cqrs.Characters.GetCharacters;
using Smash_Combos.Core.Cqrs.Characters.PostCharacter;
using Smash_Combos.Core.Cqrs.Characters.PutCharacter;
using Smash_Combos.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<GetCharactersResponse>>> GetCharacters([FromQuery] string filter) => Ok(await _mediator.Send(new GetCharactersRequest { Filter = filter }));

        // GET: api/Characters/5
        //
        // Fetches and returns a specific character by finding it by id. The id is specified in the
        // URL. In the sample URL above it is the `5`.  The "{id}" in the [HttpGet("{id}")] is what tells dotnet
        // to grab the id from the URL. It is then made available to us as the `id` argument to the method.
        //
        [HttpGet("{variableName}")]
        public async Task<ActionResult<GetCharacterResponse>> GetCharacter([FromRoute] string variableName) => Ok(await _mediator.Send(new GetCharacterRequest { VariableName = variableName }));

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
                return BadRequest(new StatusCodeProblemDetails(400) { Detail = "Name in URL and Character don't match" });

            request.CurrentUserId = GetCurrentUserId();

            var response = await _mediator.Send(request); ;

            if (response != null)
                return Ok();
            else
                return StatusCode(500);
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

            if (response != null)
                return CreatedAtAction("GetCharacter", new { id = response.Id }, response);
            else
                return StatusCode(500);
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
