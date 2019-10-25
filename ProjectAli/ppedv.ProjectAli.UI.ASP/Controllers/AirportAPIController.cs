using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ppedv.ProjectAli.Data.EF;
using ppedv.ProjectAli.Domain;

namespace ppedv.ProjectAli.UI.ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("text/xml")]
    public class AirportAPIController : ControllerBase
    {
        private readonly EFContext _context;

        public AirportAPIController()
        {
            _context = new EFContext();
        }

        // GET: api/AirportAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Airport>>> GetAirport()
        {
            return await _context.Airport.ToListAsync();
        }

        // GET: api/AirportAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Airport>> GetAirport(int id)
        {
            var airport = await _context.Airport.FindAsync(id);

            if (airport == null)
            {
                return NotFound();
            }

            return airport;
        }

        // PUT: api/AirportAPI/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirport(int id, Airport airport)
        {
            if (id != airport.ID)
            {
                return BadRequest();
            }

            _context.Entry(airport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirportExists(id))
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

        // POST: api/AirportAPI
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Airport>> PostAirport(Airport airport)
        {
            _context.Airport.Add(airport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirport", new { id = airport.ID }, airport);
        }

        // DELETE: api/AirportAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Airport>> DeleteAirport(int id)
        {
            var airport = await _context.Airport.FindAsync(id);
            if (airport == null)
            {
                return NotFound();
            }

            _context.Airport.Remove(airport);
            await _context.SaveChangesAsync();

            return airport;
        }

        private bool AirportExists(int id)
        {
            return _context.Airport.Any(e => e.ID == id);
        }
    }
}
