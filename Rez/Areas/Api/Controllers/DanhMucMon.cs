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
    [Route("[area]/[controller]")]
    [ApiController]
    public class DanhMucMon : ControllerBase
    {
        private readonly AppDbContext database;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        public DanhMucMon(AppDbContext database)
        {
            this.database = database;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: api/DanhMucMon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.DanhMucMon>>> GetAll()
        {
            return await database.DanhSachMon.ToListAsync(HttpContext.RequestAborted);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/DanhMucMon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.DanhMucMon>> Get(Guid id)
        {
            var danhMucMon = await database.DanhSachMon.FirstOrDefaultAsync(x=>x.Id == id, HttpContext.RequestAborted);

            if (danhMucMon == null)
            {
                return NotFound();
            }

            return danhMucMon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="danhMucMon"></param>
        /// <returns></returns>
        // PUT: api/DanhMucMon/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDanhMucMon(Guid id, Models.DanhMucMon danhMucMon)
        {
            if (id != danhMucMon.Id)
            {
                return BadRequest();
            }

            database.Entry(danhMucMon).State = EntityState.Modified;

            try
            {
                await database.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DanhMucMonExists(id))
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
        /// <param name="danhMucMon"></param>
        /// <returns></returns>
        // POST: api/DanhMucMons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.DanhMucMon>> Post(Models.DanhMucMon danhMucMon)
        {
            database.DanhSachMon.Add(danhMucMon);
            await database.SaveChangesAsync(HttpContext.RequestAborted);

            return CreatedAtAction("GetDanhMucMon", new { id = danhMucMon.Id }, danhMucMon);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/DanhMucMons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDanhMucMon(Guid id)
        {
            var danhMucMon = await database.DanhSachMon.FindAsync(id, HttpContext.RequestAborted);
            if (danhMucMon == null)
            {
                return NotFound();
            }

            database.DanhSachMon.Remove(danhMucMon);
            await database.SaveChangesAsync(HttpContext.RequestAborted);

            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DanhMucMonExists(Guid id)
        {
            return database.DanhSachMon.Any(e => e.Id == id);
        }
    }
}
