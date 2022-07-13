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
    public class payment_infoController : ControllerBase
    {
        private readonly ContextDB _context;

        public payment_infoController(ContextDB context)
        {
            _context = context;
        }

        // GET: api/payment_info
        [HttpGet]
        public async Task<ActionResult<IEnumerable<payment_info>>> Getpayment_info_1()
        {
          if (_context.payment_info == null)
          {
              return NotFound();
          }
            return await _context.payment_info.ToListAsync();
        }

        // GET: api/payment_info/5
        [HttpGet("{id}")]
        public async Task<ActionResult<payment_info>> Getpayment_info(int id)
        {
          if (_context.payment_info == null)
          {
              return NotFound();
          }
            var payment_info = await _context.payment_info.FindAsync(id);

            if (payment_info == null)
            {
                return NotFound();
            }

            return payment_info;
        }

        // PUT: api/payment_info/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpayment_info(int id, payment_info payment_info)
        {
            if (id != payment_info.pay_id)
            {
                return BadRequest();
            }

            _context.Entry(payment_info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!payment_infoExists(id))
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

        // POST: api/payment_info
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<payment_info>> Postpayment_info(payment_info payment_info)
        {
          if (_context.payment_info == null)
          {
              return Problem("Entity set 'ContextDB.payment_info_1'  is null.");
          }
            _context.payment_info.Add(payment_info);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpayment_info", new { id = payment_info.pay_id }, payment_info);
        }

        // DELETE: api/payment_info/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepayment_info(int id)
        {
            if (_context.payment_info == null)
            {
                return NotFound();
            }
            var payment_info = await _context.payment_info.FindAsync(id);
            if (payment_info == null)
            {
                return NotFound();
            }

            _context.payment_info.Remove(payment_info);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool payment_infoExists(int id)
        {
            return (_context.payment_info?.Any(e => e.pay_id == id)).GetValueOrDefault();
        }
    }
}
