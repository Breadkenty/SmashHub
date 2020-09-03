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
using Smash_Combos.Core.Cqrs.Reports.PutReport;
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
        public async Task<ActionResult<IEnumerable<GetReportsResponse>>> GetReports()
        {
            var response = await _mediator.Send(new GetReportsRequest());
            return Ok(response);
        }

        // GET api/<ReportsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetReportResponse>> GetReport([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetReportRequest { ReportId = id });
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        // Get api/<ReportsController/displayName
        [HttpGet("user/{displayName}")]
        public async Task<ActionResult<GetReportsByUserResponse>> GetReportsByUser([FromRoute] string userName)
        {
            var response = await _mediator.Send(new GetReportsByUserRequest { UserName = userName });
            if (response == null)
                return NotFound();
            
            return Ok(response);
        }

        // POST api/<ReportsControler>/combo/5
        [HttpPost("combo/{comboId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PostComboReportResponse>> PostComboReport([FromRoute] int comboId, [FromBody] PostComboReportRequest postComboReportRequest)
        {
            if (comboId != postComboReportRequest.ComboId)
                return BadRequest();

            var response = await _mediator.Send(postComboReportRequest);

            if (response.User == null || response.Reporter == null)
                return NotFound();

            // Return a response that indicates the object was created (status code `201`) and some additional headers with details of the newly created object.
            return CreatedAtAction("GetReport", new { id = response.Id }, response);
        }

        // POST api/<ReportsControler>/comment/5
        [HttpPost("comment/{commentId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PostCommentReportResponse>> PostCommentReport([FromRoute] int commentId, [FromBody] PostCommentReportRequest postCommentReportRequest)
        {
            if (commentId != postCommentReportRequest.CommentId)
                return BadRequest();

            var response = await _mediator.Send(postCommentReportRequest);

            if (response.User == null || response.Reporter == null)
                return NotFound();

            // Return a response that indicates the object was created (status code `201`) and some additional headers with details of the newly created object.
            return CreatedAtAction("GetReport", new { id = response.Id }, response);
        }

        // PUT api/<ReportsController>/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PutReportResponse>> PutReport([FromRoute] int id, [FromBody] PutReportRequest putReportRequest)
        {
            if (id != putReportRequest.Id) // If the ID in the URL does not match the ID in the supplied request body, return a bad request
                return BadRequest();

            try
            {
                var response = await _mediator.Send(putReportRequest);

                if (response.Success)
                    return Ok(response.Report); // Return the updated report.
                else if (response.Report == null)
                    return NotFound();
                else
                    return StatusCode(500); // The report was found, but couldn't be updated -> something went wrong. How should we handle this?
            }
            catch (DbUpdateConcurrencyException)
            {
                throw; // Should we throw the exception here or deal with it otherwise?
            }
        }

        // DELETE api/<ReportsController>/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> DeleteReport([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteReportRequest { ReportId = id, UserId = GetCurrentUserId() });

            if (response.Report == null) // There wasn't a report with that id so return a `404` not found
                return NotFound();

            return Ok(response.Report); // Send back a copy of the deleted data.
        }

        private int GetCurrentUserId()
        {
            // Get the User Id from the claim and then parse it as an integer.
            return int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);
        }
    }
}
