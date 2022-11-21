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
    public class LoginTsController : ControllerBase
    {
        private readonly ClaimsContext _context;

        public LoginTsController(ClaimsContext context)
        {
            _context = context;
        }

        // GET: api/LoginTs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginT>>> GetLoginTs()
        {
            return await _context.LoginTs.ToListAsync();
        }

        // GET: api/LoginTs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginT>> GetLoginT(int id)
        {
            var LoginT = await _context.LoginTs.FindAsync(id);

            if (LoginT == null)
            {
                return NotFound();
            }

            return LoginT;
        }

        // PUT: api/LoginTs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginT(string username, LoginT LoginT)
        {
            if (username != LoginT.Username)
            {
                return BadRequest();
            }

            _context.Entry(LoginT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginTExists(username))
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

        // POST: api/LoginTs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create")]
        public async Task<ActionResult<LoginT>> PostLoginT(LoginT LoginT)
        {
            _context.LoginTs.Add(LoginT);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoginT", new { id = LoginT.Username }, LoginT);
        }

        [HttpPost("check")]
        public async Task<Boolean> Check(LoginT loginT)
        {
            LoginT user = await _context.LoginTs.FindAsync(loginT.Username);
            if (user != null && user.Password.Trim().ToLower() == loginT.Password.Trim().ToLower())
            {

                return true;
            }
            return false;
        }

        [HttpPost("Getname")]
        public async Task<string>Getname(LoginT logint)
        {
            LoginT user = await _context.LoginTs.FindAsync(logint.Username);
            return user.FirstName;
        }
        // DELETE: api/LoginTs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginT(int id)
        {
            var LoginT = await _context.LoginTs.FindAsync(id);
            if (LoginT == null)
            {
                return NotFound();
            }

            _context.LoginTs.Remove(LoginT);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginTExists(string username)
        {
            return _context.LoginTs.Any(e => e.Username == username);
        }
    }
}
