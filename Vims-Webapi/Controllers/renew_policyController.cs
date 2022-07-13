using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vims_Webapi.Model;

namespace Vims_Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class renew_policyController : ControllerBase
    {
        private readonly ContextDB _context;

        public renew_policyController(ContextDB context)
        {
            _context = context;
        }

        // GET: api/renew_policy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<renew_policy>>> Getrenew_policy()
        {
          if (_context.renew_policy == null)
          {
              return NotFound();
          }
            return await _context.renew_policy.ToListAsync();
        }

        // GET: api/renew_policy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<renew_policy>> Getrenew_policy(int id)
        {
          if (_context.renew_policy == null)
          {
              return NotFound();
          }
            var renew_policy = await _context.renew_policy.FindAsync(id);

            if (renew_policy == null)
            {
                return NotFound();
            }

            return renew_policy;
        }

        // PUT: api/renew_policy/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrenew_policy(int id, renew_policy renew_policy)
        {
            if (id != renew_policy.id)
            {
                return BadRequest();
            }

            _context.Entry(renew_policy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!renew_policyExists(id))
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

        // POST: api/renew_policy
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<renew_policy>> Postrenew_policy(renew_policy renew_policy)
        {
          if (_context.renew_policy == null)
          {
              return Problem("Entity set 'ContextDB.renew_policy'  is null.");
          }
            _context.renew_policy.Add(renew_policy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrenew_policy", new { id = renew_policy.id }, renew_policy);
        }

        // DELETE: api/renew_policy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleterenew_policy(int id)
        {
            if (_context.renew_policy == null)
            {
                return NotFound();
            }
            var renew_policy = await _context.renew_policy.FindAsync(id);
            if (renew_policy == null)
            {
                return NotFound();
            }

            _context.renew_policy.Remove(renew_policy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool renew_policyExists(int id)
        {
            return (_context.renew_policy?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
