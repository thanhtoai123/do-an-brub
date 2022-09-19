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
    public class KhoaHoc : ControllerBase
    {
        private readonly AppDbContext _context;

        public KhoaHoc(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/KhoaHoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.KhoaHoc>>> GetKhoaHoc()
        {
            return await _context.KhoaHoc.ToListAsync();
        }

        // GET: api/KhoaHoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.KhoaHoc>> GetKhoaHoc(Guid id)
        {
            var khoaHoc = await _context.KhoaHoc.FindAsync(id);

            if (khoaHoc == null)
            {
                return NotFound();
            }

            return khoaHoc;
        }

        // PUT: api/KhoaHoc/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhoaHoc(Guid id, Models.KhoaHoc khoaHoc)
        {
            if (id != khoaHoc.Id)
            {
                return BadRequest();
            }

            _context.Entry(khoaHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhoaHocExists(id))
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

        // POST: api/KhoaHoc
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KhoaHoc>> PostKhoaHoc(Models.KhoaHoc khoaHoc)
        {
            _context.KhoaHoc.Add(khoaHoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKhoaHoc", new { id = khoaHoc.Id }, khoaHoc);
        }

        // DELETE: api/KhoaHoc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhoaHoc(Guid id)
        {
            var khoaHoc = await _context.KhoaHoc.FindAsync(id);
            if (khoaHoc == null)
            {
                return NotFound();
            }

            _context.KhoaHoc.Remove(khoaHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhoaHocExists(Guid id)
        {
            return _context.KhoaHoc.Any(e => e.Id == id);
        }
    }
}
