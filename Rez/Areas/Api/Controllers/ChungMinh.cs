using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rez.Contexts;
using Rez.Models.SoYeuLyLich;

namespace Rez.Areas.Api.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [Area("api")]
    [Route("api/[controller]")]
    [ApiController]
    public class ChungMinh : ControllerBase
    {
        private readonly AppDbContext database;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        public ChungMinh(AppDbContext database)
        {
            this.database = database;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: api/ChungMinh
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.SoYeuLyLich.ChungMinh>>> GetChungMinh()
        {
            return await database.ChungMinh.ToListAsync(HttpContext.RequestAborted);
        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/ChungMinhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.SoYeuLyLich.ChungMinh>> GetChungMinh(Guid id)
        {
            var chungMinh = await database.ChungMinh.FindAsync(id);

            if (chungMinh == null)
            {
                return NotFound();
            }

            return chungMinh;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="chungMinh"></param>
        /// <returns></returns>
        // PUT: api/ChungMinhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChungMinh(Guid id, Models.SoYeuLyLich.ChungMinh chungMinh)
        {
            if (id != chungMinh.Id)
            {
                return BadRequest();
            }

            database.Entry(chungMinh).State = EntityState.Modified;

            try
            {
                await database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChungMinhExists(id))
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
        /// <param name="chungMinh"></param>
        /// <returns></returns>
        // POST: api/ChungMinhs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.SoYeuLyLich.ChungMinh>> PostChungMinh(Models.SoYeuLyLich.ChungMinh chungMinh)
        {
            database.ChungMinh.Add(chungMinh);
            await database.SaveChangesAsync();

            return CreatedAtAction("GetChungMinh", new { id = chungMinh.Id }, chungMinh);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ChungMinhs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChungMinh(Guid id)
        {
            var chungMinh = await database.ChungMinh.FindAsync(id);
            if (chungMinh == null)
            {
                return NotFound();
            }

            database.ChungMinh.Remove(chungMinh);
            await database.SaveChangesAsync();

            return NoContent();
        }

        private bool ChungMinhExists(Guid id)
        {
            return database.ChungMinh.Any(e => e.Id == id);
        }
    }
}
