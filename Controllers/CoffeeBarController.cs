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
    public class CoffeeBarController : ControllerBase
    {
        private readonly BARContext _context;

        public CoffeeBarController(BARContext context)
        {
            _context = context;
        }

        // GET: api/CoffeeBar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoffeeBar>>> GetCoffeeBars()
        {
          if (_context.CoffeeBars == null)
          {
              return NotFound();
          }
            return await _context.CoffeeBars.ToListAsync();
        }

        // GET: api/CoffeeBar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoffeeBar>> GetCoffeeBar(string id)
        {
          if (_context.CoffeeBars == null)
          {
              return NotFound();
          }
            var coffeeBar = await _context.CoffeeBars.FindAsync(id);

            if (coffeeBar == null)
            {
                return NotFound();
            }

            return coffeeBar;
        }

        // PUT: api/CoffeeBar/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoffeeBar(string id, CoffeeBar coffeeBar)
        {
            if (id != coffeeBar.Id)
            {
                return BadRequest();
            }

            _context.Entry(coffeeBar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoffeeBarExists(id))
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

        // POST: api/CoffeeBar
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoffeeBar>> PostCoffeeBar(CoffeeBar coffeeBar)
        {
          if (_context.CoffeeBars == null)
          {
              return Problem("Entity set 'BARContext.CoffeeBars'  is null.");
          }
            _context.CoffeeBars.Add(coffeeBar);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CoffeeBarExists(coffeeBar.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCoffeeBar", new { id = coffeeBar.Id }, coffeeBar);
        }

        // DELETE: api/CoffeeBar/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoffeeBar(string id)
        {
            if (_context.CoffeeBars == null)
            {
                return NotFound();
            }
            var coffeeBar = await _context.CoffeeBars.FindAsync(id);
            if (coffeeBar == null)
            {
                return NotFound();
            }

            _context.CoffeeBars.Remove(coffeeBar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoffeeBarExists(string id)
        {
            return (_context.CoffeeBars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
