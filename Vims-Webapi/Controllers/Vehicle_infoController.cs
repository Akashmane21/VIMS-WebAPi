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
    public class Vehicle_infoController : ControllerBase
    {
        private readonly ContextDB _context;

        public Vehicle_infoController(ContextDB context)
        {
            _context = context;
        }

        // GET: api/Vehicle_info
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle_info>>> Getvehicle_info()
        {
          if (_context.vehicle_info == null)
          {
              return NotFound();
          }
            return await _context.vehicle_info.ToListAsync();
        }

        // GET: api/Vehicle_info/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle_info>> GetVehicle_info(int id)
        {
          if (_context.vehicle_info == null)
          {
              return NotFound();
          }
            var vehicle_info = await _context.vehicle_info.FindAsync(id);

            if (vehicle_info == null)
            {
                return NotFound();
            }

            return vehicle_info;
        }

        // PUT: api/Vehicle_info/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle_info(int id, Vehicle_info vehicle_info)
        {
            if (id != vehicle_info.vehid)
            {
                return BadRequest();
            }

            _context.Entry(vehicle_info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Vehicle_infoExists(id))
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

        // POST: api/Vehicle_info
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehicle_info>> PostVehicle_info(Vehicle_info vehicle_info)
        {
          if (_context.vehicle_info == null)
          {
              return Problem("Entity set 'ContextDB.vehicle_info'  is null.");
          }
            _context.vehicle_info.Add(vehicle_info);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicle_info", new { id = vehicle_info.vehid }, vehicle_info);
        }

        // DELETE: api/Vehicle_info/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle_info(int id)
        {
            if (_context.vehicle_info == null)
            {
                return NotFound();
            }
            var vehicle_info = await _context.vehicle_info.FindAsync(id);
            if (vehicle_info == null)
            {
                return NotFound();
            }

            _context.vehicle_info.Remove(vehicle_info);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Vehicle_infoExists(int id)
        {
            return (_context.vehicle_info?.Any(e => e.vehid == id)).GetValueOrDefault();
        }
    }
}
