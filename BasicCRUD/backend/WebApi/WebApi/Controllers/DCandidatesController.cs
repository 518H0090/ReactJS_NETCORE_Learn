using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DCandidatesController : ControllerBase
    {
        private readonly DonationDbContext _context;

        public DCandidatesController(DonationDbContext context)
        {
            _context = context;
        }

        // GET: api/DCandidates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DCandidate>>> GetdCandidates()
        {
          if (_context.dCandidates == null)
          {
              return NotFound();
          }
            return await _context.dCandidates.ToListAsync();
        }

        // GET: api/DCandidates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DCandidate>> GetDCandidate(int id)
        {
          if (_context.dCandidates == null)
          {
              return NotFound();
          }
            var dCandidate = await _context.dCandidates.FindAsync(id);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/DCandidates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, DCandidate dCandidate)
        {
            //if (id != dCandidate.Id)
            //{
            //    return BadRequest();
            //}

            dCandidate.Id = id;

            _context.Entry(dCandidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DCandidateExists(id))
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

        // POST: api/DCandidates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DCandidate>> PostDCandidate(DCandidate dCandidate)
        {
          if (_context.dCandidates == null)
          {
              return Problem("Entity set 'DonationDbContext.dCandidates'  is null.");
          }
            _context.dCandidates.Add(dCandidate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDCandidate", new { id = dCandidate.Id }, dCandidate);
        }

        // DELETE: api/DCandidates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDCandidate(int id)
        {
            if (_context.dCandidates == null)
            {
                return NotFound();
            }
            var dCandidate = await _context.dCandidates.FindAsync(id);
            if (dCandidate == null)
            {
                return NotFound();
            }

            _context.dCandidates.Remove(dCandidate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DCandidateExists(int id)
        {
            return (_context.dCandidates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
