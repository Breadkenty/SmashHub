using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SmashCombos.Core.Cqrs.Combos.DeleteCombo;
using SmashCombos.Core.Cqrs.Combos.GetCombo;
using SmashCombos.Core.Cqrs.Combos.GetCombos;
using SmashCombos.Core.Cqrs.Combos.PostCombo;
using SmashCombos.Core.Cqrs.Combos.PutCombo;
using SmashCombos.Core.Services;
using SmashCombos.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SmashCombos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CombosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CombosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCombosResponse>>> GetCombos() => Ok(await _mediator.Send(new GetCombosRequest()));

        [HttpGet("{id}")]
        public async Task<ActionResult<GetComboResponse>> GetCombo([FromRoute] int id) => Ok(await _mediator.Send(new GetComboRequest { ComboId = id }));

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PutCombo([FromRoute] int id, [FromBody] PutComboRequest request)
        {
            if (id != request.ComboId) // If the ID in the URL does not match the ID in the supplied request body, return a bad request
                return BadRequest(new StatusCodeProblemDetails(400) { Detail = "Id in URL and Combo don't match" });

            request.CurrentUserId = GetCurrentUserId();

            var response = await _mediator.Send(request);

            if (response != null)
                return Ok();
            else
                return StatusCode(500);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PostComboResponse>> PostCombo([FromBody] PostComboRequest request)
        {
            request.CurrentUserId = GetCurrentUserId();

            var response = await _mediator.Send(request);

            if (response != null)
                return CreatedAtAction("GetCombo", new { id = response.Id }, response);
            else
                return StatusCode(500);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteCombo([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteComboRequest { ComboId = id, CurrentUserId = GetCurrentUserId() });

            if (response != null)
                return Ok();
            else
                return StatusCode(500);
        }

        private int GetCurrentUserId()
        {
            return int.Parse(User.Claims.SingleOrDefault(claim => claim.Type == "Id").Value);
        }
    }
}
