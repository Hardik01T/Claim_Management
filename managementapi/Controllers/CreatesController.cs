using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using managementapi.Models;

namespace managementapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatesController : ControllerBase
    {
        private readonly ClaimsContext _context;

        public CreatesController(ClaimsContext context)
        {
            _context = context;
        }

        // GET: api/Creates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Create>>> GetCreates()
        {
          if (_context.Creates == null)
          {
              return NotFound();
          }
            return await _context.Creates.ToListAsync();
        }

        [HttpGet("ClosedClaim")]
        public async Task<ActionResult<IEnumerable<Create>>> ClosedClaim()
        {
            if (_context.Creates == null)
            {
                return NotFound();
            }
            return _context.Creates.Where(t => t.CloseDate != null).ToList();
        }

        // GET: api/Creates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Create>> GetCreate(int id)
        {
          if (_context.Creates == null)
          {
              return NotFound();
          }
            var create = await _context.Creates.FindAsync(id);

            if (create == null)
            {
                return NotFound();
            }

            return create;
        }

        // PUT: api/Creates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreate(int id, Create create)
        {
            if (id != create.Id)
            {
                return BadRequest();
            }

            _context.Entry(create).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreateExists(id))
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

        // POST: api/Creates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Create>> PostCreate(Create create)
        {
          if (_context.Creates == null)
          {
              return Problem("Entity set 'ClaimsContext.Creates'  is null.");
          }
            _context.Creates.Add(create);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCreate", new { id = create.Id }, create);
        }

        // DELETE: api/Creates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreate(int id)
        {
            if (_context.Creates == null)
            {
                return NotFound();
            }
            var create = await _context.Creates.FindAsync(id);
            if (create == null)
            {
                return NotFound();
            }

            _context.Creates.Remove(create);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CreateExists(int id)
        {
            return (_context.Creates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
