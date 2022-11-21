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
    public class InsurersController : ControllerBase
    {
        private readonly ClaimsContext _context;

        public InsurersController(ClaimsContext context)
        {
            _context = context;
        }

        // GET: api/Insurers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Insurer>>> GetInsurers()
        {
          if (_context.Insurers == null)
          {
              return NotFound();
          }
            return await _context.Insurers.ToListAsync();
        }

        // GET: api/Insurers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Insurer>> GetInsurer(string id)
        {
          if (_context.Insurers == null)
          {
              return NotFound();
          }
            var insurer = await _context.Insurers.FindAsync(id);

            if (insurer == null)
            {
                return NotFound();
            }

            return insurer;
        }

        // PUT: api/Insurers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsurer(string id, Insurer insurer)
        {
            if (id != insurer.InsurerId)
            {
                return BadRequest();
            }

            _context.Entry(insurer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsurerExists(id))
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

        // POST: api/Insurers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Insurer>> PostInsurer(Insurer insurer)
        {
          if (_context.Insurers == null)
          {
              return Problem("Entity set 'ClaimsContext.Insurers'  is null.");
          }
            _context.Insurers.Add(insurer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InsurerExists(insurer.InsurerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInsurer", new { id = insurer.InsurerId }, insurer);
        }

        // DELETE: api/Insurers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurer(string id)
        {
            if (_context.Insurers == null)
            {
                return NotFound();
            }
            var insurer = await _context.Insurers.FindAsync(id);
            if (insurer == null)
            {
                return NotFound();
            }

            _context.Insurers.Remove(insurer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InsurerExists(string id)
        {
            return (_context.Insurers?.Any(e => e.InsurerId == id)).GetValueOrDefault();
        }
    }
}
