using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyGolfHelper.Data;
using MyGolfHelper.Models;

namespace MyGolfHelper.WebApi.Controllers
{
    [ApiController]
    [Route("api/golfclubs")]
    public class GolfClubController : ControllerBase
    {
        private readonly MyGolfHelperDbContext _context;

        public GolfClubController(MyGolfHelperDbContext context)
        {
            _context = context;
        }

        // GET: api/GolfClub
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GolfClub>>> GetGolfClubs()
        {
            return await _context.GolfClubs.ToListAsync();
        }

        // GET: api/GolfClub/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GolfClub>> GetGolfClub(long id)
        {
            var golfClub = await _context.GolfClubs.FindAsync(id);

            if (golfClub == null)
            {
                return NotFound();
            }

            return Ok(golfClub);
        }

        // PUT: api/GolfClub/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGolfClub(long id, GolfClub golfClub)
        {
            if (id != golfClub.Id)
            {
                return BadRequest();
            }

            _context.Entry(golfClub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GolfClubExists(id))
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

        // POST: api/GolfClub
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GolfClub>> PostGolfClub(GolfClub golfClub)
        {
            _context.GolfClubs.Add(golfClub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGolfClub", new { id = golfClub.Id }, golfClub);
        }

        // DELETE: api/GolfClub/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGolfClub(long id)
        {
            var golfClub = await _context.GolfClubs.FindAsync(id);
            if (golfClub == null)
            {
                return NotFound();
            }

            _context.GolfClubs.Remove(golfClub);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GolfClubExists(long id)
        {
            return _context.GolfClubs.Any(e => e.Id == id);
        }
    }
}
