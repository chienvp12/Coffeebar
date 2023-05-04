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
    public class BookedTableController : ControllerBase
    {
        private readonly BARContext _context;

        public BookedTableController(BARContext context)
        {
            _context = context;
        }

        // GET: api/BookedTable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookedTable>>> GetBookedTables()
        {
          if (_context.BookedTables == null)
          {
              return NotFound();
          }
            return await _context.BookedTables.ToListAsync();
        }

        // GET: api/BookedTable/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookedTable>> GetBookedTable(string id)
        {
          if (_context.BookedTables == null)
          {
              return NotFound();
          }
            var bookedTable = await _context.BookedTables.FindAsync(id);

            if (bookedTable == null)
            {
                return NotFound();
            }

            return bookedTable;
        }

        // PUT: api/BookedTable/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookedTable(string id, BookedTable bookedTable)
        {
            if (id != bookedTable.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookedTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookedTableExists(id))
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

        // POST: api/BookedTable
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookedTable>> PostBookedTable(BookedTable bookedTable)
        {
          if (_context.BookedTables == null)
          {
              return Problem("Entity set 'BARContext.BookedTables'  is null.");
          }
            _context.BookedTables.Add(bookedTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookedTableExists(bookedTable.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookedTable", new { id = bookedTable.Id }, bookedTable);
        }

        // DELETE: api/BookedTable/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookedTable(string id)
        {
            if (_context.BookedTables == null)
            {
                return NotFound();
            }
            var bookedTable = await _context.BookedTables.FindAsync(id);
            if (bookedTable == null)
            {
                return NotFound();
            }

            _context.BookedTables.Remove(bookedTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookedTableExists(string id)
        {
            return (_context.BookedTables?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
