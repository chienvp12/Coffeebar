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
    public class DrinkController : ControllerBase
    {
        private readonly BARContext _context;

        public DrinkController(BARContext context)
        {
            _context = context;
        }

        // GET: api/Drink
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drink>>> GetDrinks()
        {
          if (_context.Drinks == null)
          {
              return NotFound();
          }
            return await _context.Drinks.ToListAsync();
        }

        // GET: api/Drink/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drink>> GetDrink(string id)
        {
          if (_context.Drinks == null)
          {
              return NotFound();
          }
            var drink = await _context.Drinks.FindAsync(id);

            if (drink == null)
            {
                return NotFound();
            }

            return drink;
        }

        // PUT: api/Drink/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrink(string id, Drink drink)
        {
            if (id != drink.Id)
            {
                return BadRequest();
            }

            _context.Entry(drink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkExists(id))
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

        // POST: api/Drink
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Drink>> PostDrink(Drink drink)
        {
          if (_context.Drinks == null)
          {
              return Problem("Entity set 'BARContext.Drinks'  is null.");
          }
            _context.Drinks.Add(drink);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DrinkExists(drink.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDrink", new { id = drink.Id }, drink);
        }

        // DELETE: api/Drink/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrink(string id)
        {
            if (_context.Drinks == null)
            {
                return NotFound();
            }
            var drink = await _context.Drinks.FindAsync(id);
            if (drink == null)
            {
                return NotFound();
            }

            _context.Drinks.Remove(drink);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrinkExists(string id)
        {
            return (_context.Drinks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
