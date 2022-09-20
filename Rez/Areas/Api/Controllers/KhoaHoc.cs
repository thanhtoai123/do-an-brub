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
    [Area("Api")]
    [Route("/[area]/KhoaHoc")]
    [ApiController]
    public class KhoaHoc : ControllerBase
    {
        private readonly AppDbContext database;

        public KhoaHoc(AppDbContext database)
        {
            this.database = database;
        }

        // GET: api/KhoaHoc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.KhoaHoc>>> GetKhoaHoc()
        {
            return await database.KhoaHoc.ToListAsync();
        }

        // GET: api/KhoaHoc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.KhoaHoc>> GetKhoaHoc(Guid id)
        {
            var khoaHoc = await database.KhoaHoc.FindAsync(id);

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

            database.Entry(khoaHoc).State = EntityState.Modified;

            try
            {
                await database.SaveChangesAsync();
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
        public async Task<ActionResult<Models.KhoaHoc>> PostKhoaHoc(Models.KhoaHoc khoaHoc)
        {
            database.KhoaHoc.Add(khoaHoc);
            await database.SaveChangesAsync();

            return CreatedAtAction("GetKhoaHoc", new { id = khoaHoc.Id }, khoaHoc);
        }

        // DELETE: api/KhoaHoc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhoaHoc(Guid id)
        {
            var khoaHoc = await database.KhoaHoc.FindAsync(id);
            if (khoaHoc == null)
            {
                return NotFound();
            }

            database.KhoaHoc.Remove(khoaHoc);
            await database.SaveChangesAsync();

            return NoContent();
        }

        private bool KhoaHocExists(Guid id)
        {
            return database.KhoaHoc.Any(e => e.Id == id);
        }
    }
}
