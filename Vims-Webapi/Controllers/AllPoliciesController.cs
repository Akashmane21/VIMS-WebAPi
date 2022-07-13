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
    public class AllPoliciesController : ControllerBase
    {
        private readonly ContextDB _context;

        public AllPoliciesController(ContextDB context)
        {
            _context = context;
        }

        // GET: api/AllPolicies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllPolicies>>> GetAllPolicies()
        {
          if (_context.AllPolicies == null)
          {
              return NotFound();
          }
            return await _context.AllPolicies.ToListAsync();
        }

        // GET: api/AllPolicies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllPolicies>> GetAllPolicies(int id)
        {
          if (_context.AllPolicies == null)
          {
              return NotFound();
          }
            var allPolicies = await _context.AllPolicies.FindAsync(id);

            if (allPolicies == null)
            {
                return NotFound();
            }

            return allPolicies;
        }

        // PUT: api/AllPolicies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllPolicies(int id, AllPolicies allPolicies)
        {
            if (id != allPolicies.policyid)
            {
                return BadRequest();
            }

            _context.Entry(allPolicies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllPoliciesExists(id))
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

        // POST: api/AllPolicies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AllPolicies>> PostAllPolicies(AllPolicies allPolicies)
        {
          if (_context.AllPolicies == null)
          {
              return Problem("Entity set 'ContextDB.AllPolicies'  is null.");
          }
            _context.AllPolicies.Add(allPolicies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllPolicies", new { id = allPolicies.policyid }, allPolicies);
        }

        // DELETE: api/AllPolicies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllPolicies(int id)
        {
            if (_context.AllPolicies == null)
            {
                return NotFound();
            }
            var allPolicies = await _context.AllPolicies.FindAsync(id);
            if (allPolicies == null)
            {
                return NotFound();
            }

            _context.AllPolicies.Remove(allPolicies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AllPoliciesExists(int id)
        {
            return (_context.AllPolicies?.Any(e => e.policyid == id)).GetValueOrDefault();
        }
    }
}
