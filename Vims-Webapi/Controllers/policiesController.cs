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
    public class policiesController : ControllerBase
    {
        private readonly ContextDB _context;

        public policiesController(ContextDB context)
        {
            _context = context;
        }

        // GET: api/policies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<policy>>> Getpolicy()
        {
          if (_context.policy == null)
          {
              return NotFound();
          }
            return await _context.policy.ToListAsync();
        }

        // GET: api/policies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<policy>> Getpolicy(int id)
        {
          if (_context.policy == null)
          {
              return NotFound();
          }
            var policy = await _context.policy.FindAsync(id);

            if (policy == null)
            {
                return NotFound();
            }

            return policy;
        }

        // PUT: api/policies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpolicy(int id, policy policy)
        {
            if (id != policy.policyid)
            {
                return BadRequest();
            }

            _context.Entry(policy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!policyExists(id))
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

        // POST: api/policies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<policy>> Postpolicy(policy policy)
        {
          if (_context.policy == null)
          {
              return Problem("Entity set 'ContextDB.policy'  is null.");
          }
            _context.policy.Add(policy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpolicy", new { id = policy.policyid }, policy);
        }

        // DELETE: api/policies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepolicy(int id)
        {
            if (_context.policy == null)
            {
                return NotFound();
            }
            var policy = await _context.policy.FindAsync(id);
            if (policy == null)
            {
                return NotFound();
            }

            _context.policy.Remove(policy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool policyExists(int id)
        {
            return (_context.policy?.Any(e => e.policyid == id)).GetValueOrDefault();
        }
    }
}
