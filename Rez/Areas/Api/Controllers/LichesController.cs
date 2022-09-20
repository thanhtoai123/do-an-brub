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
    /// <summary>
    /// 
    /// </summary>
    [Area("Api")]
    [Route("/[area]/[controller]")]
    [ApiController]
    public class Lich : ControllerBase
    {
        private readonly AppDbContext database;

        public Lich(AppDbContext database)
        {
            this.database = database;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: api/Lich
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Lich>>> GetAll()
        {
            return await database.Lich.ToListAsync(HttpContext.RequestAborted);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Lich/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Lich>> Get(Guid id)
        {
            var lich = await database.Lich.FindAsync(id,HttpContext.RequestAborted);

            if (lich == null)
            {
                return NotFound();
            }

            return lich;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lich"></param>
        /// <returns></returns>
        // PUT: api/Lich/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLich(Guid id, Models.Lich lich)
        {
            if (id != lich.Id)
            {
                return BadRequest();
            }

            database.Entry(lich).State = EntityState.Modified;

            try
            {
                await database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LichExists(id))
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lich"></param>
        /// <returns></returns>
        // POST: api/Liches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.Lich>> Post(Models.Lich lich)
        {
            database.Lich.Add(lich);
            await database.SaveChangesAsync(HttpContext.RequestAborted);

            return CreatedAtAction("Get", new { id = lich.Id }, lich);
        }

        // DELETE: api/Lich/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var lich = await database.Lich.FindAsync(id);
            if (lich == null)
            {
                return NotFound();
            }

            database.Lich.Remove(lich);
            await database.SaveChangesAsync();

            return NoContent();
        }

        private bool LichExists(Guid id)
        {
            return database.Lich.Any(e => e.Id == id);
        }
    }
}
