using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coffee.Entities;

namespace Coffee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDrinkController : ControllerBase
    {
        private readonly BARContext _context;

        public UserDrinkController(BARContext context)
        {
            _context = context;
        }

        // GET: api/UserDrink
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDrink>>> GetUserDrinks()
        {
          if (_context.UserDrinks == null)
          {
              return NotFound();
          }
            return await _context.UserDrinks.ToListAsync();
        }

        // GET: api/UserDrink/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDrink>> GetUserDrink(string id)
        {
          if (_context.UserDrinks == null)
          {
              return NotFound();
          }
            var userDrink = await _context.UserDrinks.FindAsync(id);

            if (userDrink == null)
            {
                return NotFound();
            }

            return userDrink;
        }

        // PUT: api/UserDrink/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDrink(string id, UserDrink userDrink)
        {
            if (id != userDrink.Id)
            {
                return BadRequest();
            }

            _context.Entry(userDrink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDrinkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserDrink
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserDrink>> PostUserDrink(UserDrink userDrink)
        {
          if (_context.UserDrinks == null)
          {
              return Problem("Entity set 'BARContext.UserDrinks'  is null.");
          }
            _context.UserDrinks.Add(userDrink);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserDrinkExists(userDrink.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserDrink", new { id = userDrink.Id }, userDrink);
        }

        // DELETE: api/UserDrink/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserDrink(string id)
        {
            if (_context.UserDrinks == null)
            {
                return NotFound();
            }
            var userDrink = await _context.UserDrinks.FindAsync(id);
            if (userDrink == null)
            {
                return NotFound();
            }

            _context.UserDrinks.Remove(userDrink);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserDrinkExists(string id)
        {
            return (_context.UserDrinks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
