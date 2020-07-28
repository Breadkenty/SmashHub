using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Smash_Combos.Models;

namespace Smash_Combos.Controllers
{
    // All of these routes will be at the base URL:     /api/Combos
    // That is what "api/[controller]" means below. It uses the name of the controller
    // in this case CombosController to determine the URL
    [Route("api/[controller]")]
    [ApiController]
    public class CombosController : ControllerBase
    {
        // This is the variable you use to have access to your database
        private readonly DatabaseContext _context;
        private readonly string YOUTUBE_API_KEY;

        // Constructor that recives a reference to your database context
        // and stores it in _context for you to use in your API methods
        public CombosController(DatabaseContext context, IConfiguration config)
        {
            _context = context;
            YOUTUBE_API_KEY = config["YOUTUBE_API_KEY"];
        }

        // GET: api/Combos
        //
        // Returns a list of all your Combos
        //
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Combo>>> GetCombos()
        {
            return await _context.Combos.Include(combo => combo.User).Include(combo => combo.Comments).ToListAsync();
        }

        // GET: api/Combos/5
        //
        // Fetches and returns a specific combo by finding it by id. The id is specified in the
        // URL. In the sample URL above it is the `5`.  The "{id}" in the [HttpGet("{id}")] is what tells dotnet
        // to grab the id from the URL. It is then made available to us as the `id` argument to the method.
        //
        [HttpGet("{id}")]
        public async Task<ActionResult<Combo>> GetCombo(int id)
        {
            var combo = await _context.Combos.Where(combo => combo.Id == id).Include(combo => combo.User).Include(combo => combo.Comments).ThenInclude(comment => comment.User).FirstOrDefaultAsync();

            if (combo == null)
            {
                // Return a `404` response to the client indicating we could not find a combo with this id
                return NotFound();
            }

            //  Return the combo as a JSON object.
            return combo;
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
            // If the ID in the URL does not match the ID in the supplied request body, return a bad request
            if (id != combo.Id)
            {
                return BadRequest();
            }

            var comboExists = await _context.Combos.Where(combo => combo.Id == id && combo.UserId == GetCurrentUserId()).AnyAsync();
            if (!comboExists)
            {

                return NotFound();
            }

            // Tell the database to consider everything in combo to be _updated_ values. When
            // the save happens the database will _replace_ the values in the database with the ones from combo
            _context.Entry(combo).State = EntityState.Modified;

            try
            {
                // Try to save these changes.
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Ooops, looks like there was an error, so check to see if the record we were
                // updating no longer exists.
                if (!ComboExists(id))
                {
                    // If the record we tried to update was already deleted by someone else,
                    // return a `404` not found
                    return NotFound();
                }

                else
                {
                    // Otherwise throw the error back, which will cause the request to fail
                    // and generate an error to the client.
                    throw;
                }
            }

            // return NoContent to indicate the update was done. Alternatively you can use the
            // following to send back a copy of the updated data.
            //
            return Ok(combo);
            //
            // return NoContent();
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
        public async Task<ActionResult<Combo>> PostCombo(Combo combo)
        {
            combo.UserId = GetCurrentUserId();
            // Indicate to the database context we want to add this new record
            _context.Combos.Add(combo);
            await _context.SaveChangesAsync();

            // Return a response that indicates the object was created (status code `201`) and some additional
            // headers with details of the newly created object.
            return CreatedAtAction("GetCombo", new { id = combo.Id }, combo);
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
            // Find this combo by looking for the specific id
            var combo = await _context.Combos.Where(combo => combo.Id == id && combo.UserId == GetCurrentUserId()).FirstOrDefaultAsync();
            if (combo == null)
            {
                // There wasn't a combo with that id so return a `404` not found
                return NotFound();
            }

            // Tell the database we want to remove this record
            _context.Combos.Remove(combo);

            // Tell the database to perform the deletion
            await _context.SaveChangesAsync();

            // return NoContent to indicate the update was done. Alternatively you can use the
            // following to send back a copy of the deleted data.
            //
            return Ok(combo);
            //
            // return NoContent();
        }

        // Private helper method that looks up an existing combo by the supplied id
        private bool ComboExists(int id)
        {
            return _context.Combos.Any(combo => combo.Id == id);
        }

        private int GetCurrentUserId()
        {
            // Get the User Id from the claim and then parse it as an integer.
            return int.Parse(User.Claims.FirstOrDefault(claim => claim.Type == "Id").Value);
        }
    }
}
