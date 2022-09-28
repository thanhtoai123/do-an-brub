using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rez.Contexts;
using Rez.Models;

namespace Rez.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietLich : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChiTietLich(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ChiTietLich
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietLich>>> GetChiTietLich()
        {
          if (_context.ChiTietLich == null)
          {
              return NotFound();
          }
            return await _context.ChiTietLich.ToListAsync();
        }

        // GET: api/ChiTietLich/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietLich>> GetChiTietLich(Guid id)
        {
          if (_context.ChiTietLich == null)
          {
              return NotFound();
          }
            var chiTietLich = await _context.ChiTietLich.FindAsync(id);

            if (chiTietLich == null)
            {
                return NotFound();
            }

            return chiTietLich;
        }

        // PUT: api/ChiTietLich/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiTietLich(Guid id, ChiTietLich chiTietLich)
        {
            if (id != chiTietLich.Id)
            {
                return BadRequest();
            }

            _context.Entry(chiTietLich).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietLichExists(id))
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

        // POST: api/ChiTietLich
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiTietLich>> PostChiTietLich(ChiTietLich chiTietLich)
        {
          if (_context.ChiTietLich == null)
          {
              return Problem("Entity set 'AppDbContext.ChiTietLich'  is null.");
          }
            _context.ChiTietLich.Add(chiTietLich);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChiTietLich", new { id = chiTietLich.Id }, chiTietLich);
        }

        // DELETE: api/ChiTietLich/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiTietLich(Guid id)
        {
            if (_context.ChiTietLich == null)
            {
                return NotFound();
            }
            var chiTietLich = await _context.ChiTietLich.FindAsync(id);
            if (chiTietLich == null)
            {
                return NotFound();
            }

            _context.ChiTietLich.Remove(chiTietLich);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChiTietLichExists(Guid id)
        {
            return (_context.ChiTietLich?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
