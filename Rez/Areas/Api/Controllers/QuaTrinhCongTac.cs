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
    [Area("Api")]
    [Route("/[area]/[controller]")]
    [ApiController]
    public class QuaTrinhCongTac : ControllerBase
    {
        private readonly AppDbContext database;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        public QuaTrinhCongTac(AppDbContext database)
        {
            this.database = database;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: api/QuaTrinhCongTacs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.SoYeuLyLich.QuaTrinhCongTac>>> GetAll()
        {
            return await database.QuaTrinhCongTac.ToListAsync(HttpContext.RequestAborted);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/QuaTrinhCongTac/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.SoYeuLyLich.QuaTrinhCongTac>> Get(Guid id)
        {
            var quaTrinhCongTac = await database.QuaTrinhCongTac.FindAsync(id,HttpContext.RequestAborted);

            if (quaTrinhCongTac == null)
            {
                return NotFound();
            }

            return quaTrinhCongTac;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quaTrinhCongTac"></param>
        /// <returns></returns>
        // PUT: api/QuaTrinhCongTac/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Models.SoYeuLyLich.QuaTrinhCongTac quaTrinhCongTac)
        {
            if (id != quaTrinhCongTac.Id)
            {
                return BadRequest();
            }

            database.Entry(quaTrinhCongTac).State = EntityState.Modified;

            try
            {
                await database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuaTrinhCongTacExists(id))
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
        /// <param name="quaTrinhCongTac"></param>
        /// <returns></returns>
        // POST: api/QuaTrinhCongTacs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.SoYeuLyLich.QuaTrinhCongTac>> Post(Models.SoYeuLyLich.QuaTrinhCongTac quaTrinhCongTac)
        {
            database.QuaTrinhCongTac.Add(quaTrinhCongTac);
            await database.SaveChangesAsync(HttpContext.RequestAborted);

            return CreatedAtAction("GetQuaTrinhCongTac", new { id = quaTrinhCongTac.Id }, quaTrinhCongTac);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/QuaTrinhCongTacs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var quaTrinhCongTac = await database.QuaTrinhCongTac.FindAsync(id,HttpContext.RequestAborted);
            if (quaTrinhCongTac == null)
            {
                return NotFound();
            }

            database.QuaTrinhCongTac.Remove(quaTrinhCongTac);
            await database.SaveChangesAsync(HttpContext.RequestAborted);

            return NoContent();
        }

        private bool QuaTrinhCongTacExists(Guid id)
        {
            return database.QuaTrinhCongTac.Any(e => e.Id == id);
        }
    }
}
