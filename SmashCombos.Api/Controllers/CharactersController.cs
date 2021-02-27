using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmashCombos.Core.Cqrs;
using SmashCombos.Core.Cqrs.Characters.DeleteCharacter;
using SmashCombos.Core.Cqrs.Characters.GetCharacter;
using SmashCombos.Core.Cqrs.Characters.GetCharacters;
using SmashCombos.Core.Cqrs.Characters.PostCharacter;
using SmashCombos.Core.Cqrs.Characters.PutCharacter;
using SmashCombos.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmashCombos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CharactersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCharactersResponse>>> GetCharacters([FromQuery] string filter) => Ok(await _mediator.Send(new GetCharactersRequest { Filter = filter }));

        [HttpGet("{variableName}")]
        public async Task<ActionResult<GetCharacterResponse>> GetCharacter([FromRoute] string variableName) => Ok(await _mediator.Send(new GetCharacterRequest { VariableName = variableName }));

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
