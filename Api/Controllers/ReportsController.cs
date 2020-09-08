using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Cqrs.Reports.DeleteReport;
using Smash_Combos.Core.Cqrs.Reports.GetReport;
using Smash_Combos.Core.Cqrs.Reports.GetReportsByUser;
using Smash_Combos.Core.Cqrs.Reports.GetReports;
using Smash_Combos.Core.Cqrs.Reports.PostComboReport;
using Smash_Combos.Core.Cqrs.Reports.PostCommentReport;
using Smash_Combos.Core.Cqrs.Reports.DismissReport;
using Smash_Combos.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smash_Combos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ReportsController>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<GetReportsResponse>>> GetReports()
        {
            var response = await _mediator.Send(new GetReportsRequest { ModeratorId = GetCurrentUserId() });
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

        // GET api/<ReportsController>/5
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<GetReportResponse>> GetReport([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetReportRequest { ReportId = id, ModeratorId = GetCurrentUserId() });

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

        // Get api/<ReportsController/displayName
        [HttpGet("user/{userName}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<GetReportsByUserResponse>> GetReportsByUser([FromRoute] string userName)
        {
            var response = await _mediator.Send(new GetReportsByUserRequest { UserName = userName, ModeratorId = GetCurrentUserId() });

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

        // POST api/<ReportsControler>/combo/5
        [HttpPost("combo/{comboId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PostComboReportResponse>> PostComboReport([FromRoute] int comboId, [FromBody] PostComboReportRequest request)
        {
            if (comboId != request.ComboId)
                return BadRequest();

            var response = await _mediator.Send(request);

            switch (response.ResponseStatus)
            {
                case Core.Cqrs.ResponseStatus.Ok:
                    return CreatedAtAction("GetReport", new { id = response.Data.Id }, response);
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

        // POST api/<ReportsControler>/comment/5
        [HttpPost("comment/{commentId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PostCommentReportResponse>> PostCommentReport([FromRoute] int commentId, [FromBody] PostCommentReportRequest request)
        {
            if (commentId != request.CommentId)
                return BadRequest();

            var response = await _mediator.Send(request);

            switch (response.ResponseStatus)
            {
                case Core.Cqrs.ResponseStatus.Ok:
                    return CreatedAtAction("GetReport", new { id = response.Data.Id }, response);
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

        // PUT api/<ReportsController>/5
        [HttpPut("dismiss/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<DismissReportResponse>> DismissReport([FromRoute] int id, [FromBody] DismissReportRequest request)
        {
            if (id != request.ReportId) // If the ID in the URL does not match the ID in the supplied request body, return a bad request
                return BadRequest();

            request.ModeratorId = GetCurrentUserId();

            var response = await _mediator.Send(request);

            switch (response.ResponseStatus)
            {
                case Core.Cqrs.ResponseStatus.Ok:
                    return Ok();
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

        // DELETE api/<ReportsController>/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> DeleteReport([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteReportRequest { ReportId = id, ModeratorId = GetCurrentUserId() });

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
