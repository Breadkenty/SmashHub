using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Models;

namespace Smash_Combos.Controllers
{
    // All of these routes will be at the base URL:     /api/Characters
    // That is what "api/[controller]" means below. It uses the name of the controller
    // in this case CharactersController to determine the URL
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        // This is the variable you use to have access to your database
        private readonly DatabaseContext _context;

        // Constructor that recives a reference to your database context
        // and stores it in _context for you to use in your API methods
        public CharactersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Characters
        //
        // Returns a list of all your Characters
        //
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters(string filter)
        {
            if (filter == null)
            {
                return await _context.Characters.Include(character => character.Combos).ToListAsync();

            }
            else
            {
                return await _context.Characters.Where(character => character.Name.ToLower().Contains(filter) || character.VariableName.ToLower().Contains(filter)).Include(character => character.Combos).ToListAsync();
            }
        }

        // GET: api/Characters/5
        //
        // Fetches and returns a specific character by finding it by id. The id is specified in the
        // URL. In the sample URL above it is the `5`.  The "{id}" in the [HttpGet("{id}")] is what tells dotnet
        // to grab the id from the URL. It is then made available to us as the `id` argument to the method.
        //
        [HttpGet("{variableName}")]
        public async Task<ActionResult<Character>> GetCharacter(string variableName)
        {
            // Find the character in the database using `FindAsync` to look it up by id
            var character = await _context.Characters.Where(character => character.VariableName == variableName).Include(character => character.Combos).FirstOrDefaultAsync();

            // If we didn't find anything, we receive a `null` in return
            if (character == null)
            {
                // Return a `404` response to the client indicating we could not find a character with this id
                return NotFound();
            }

            //  Return the character as a JSON object.
            return character;
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
        public async Task<IActionResult> PutCharacter(string variableName, Character character)
        {
            // If the ID in the URL does not match the ID in the supplied request body, return a bad request
            if (variableName != character.VariableName)
            {
                return BadRequest();
            }

            // Tell the database to consider everything in character to be _updated_ values. When
            // the save happens the database will _replace_ the values in the database with the ones from character
            _context.Entry(character).State = EntityState.Modified;

            try
            {
                // Try to save these changes.
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Ooops, looks like there was an error, so check to see if the record we were
                // updating no longer exists.
                if (!CharacterExists(variableName))
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
            return Ok(character);
            //
            // return NoContent();
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
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
            // Indicate to the database context we want to add this new record
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            // Return a response that indicates the object was created (status code `201`) and some additional
            // headers with details of the newly created object.
            return CreatedAtAction("GetCharacter", new { variableName = character.VariableName }, character);
        }

        // DELETE: api/Characters/5
        //
        // Deletes an individual character with the requested id. The id is specified in the URL
        // In the sample URL above it is the `5`. The "{id} in the [HttpDelete("{id}")] is what tells dotnet
        // to grab the id from the URL. It is then made available to us as the `id` argument to the method.
        //
        [HttpDelete("{variableName}")]
        public async Task<IActionResult> DeleteCharacter(string variableName)
        {
            // Find this character by looking for the specific id
            var character = await _context.Characters.Where(character => character.VariableName == variableName).Include(character => character.Combos).FirstOrDefaultAsync();
            if (character == null)
            {
                // There wasn't a character with that id so return a `404` not found
                return NotFound();
            }

            // Tell the database we want to remove this record
            _context.Characters.Remove(character);

            // Tell the database to perform the deletion
            await _context.SaveChangesAsync();

            // return NoContent to indicate the update was done. Alternatively you can use the
            // following to send back a copy of the deleted data.
            //
            // return Ok(character)
            //
            return NoContent();
        }

        // Private helper method that looks up an existing character by the supplied id
        private bool CharacterExists(string variableName)
        {
            return _context.Characters.Any(character => character.VariableName == variableName);
        }
    }
}
