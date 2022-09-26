using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rez.Contexts;

namespace Rez.Areas.Api.Controllers;

/// <summary>
/// </summary>
[Area("Api")]
[Route("[area]/[controller]")]
[ApiController]
public class DanhMucMon : ControllerBase
{
    private readonly AppDbContext _database;

    /// <summary>
    /// </summary>
    /// <param name="database"></param>
    public DanhMucMon(AppDbContext database)
    {
        _database = database;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    // GET: api/DanhMucMon
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.DanhMucMon>>> GetAll()
    {
        return await _database.DanhSachMon.ToListAsync(HttpContext.RequestAborted);
    }

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // GET: api/DanhMucMon/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Models.DanhMucMon>> Get(Guid id)
    {
        var danhMucMon = await _database.DanhSachMon.FirstOrDefaultAsync(x => x.Id == id, HttpContext.RequestAborted);

        if (danhMucMon == null) return NotFound();

        return danhMucMon;
    }

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="danhMucMon"></param>
    /// <returns></returns>
    // PUT: api/DanhMucMon/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDanhMucMon(Guid id, Models.DanhMucMon danhMucMon)
    {
        if (id != danhMucMon.Id) return BadRequest();

        _database.Entry(danhMucMon).State = EntityState.Modified;

        try
        {
            await _database.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DanhMucMonExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    /// <summary>
    /// </summary>
    /// <param name="danhMucMon"></param>
    /// <returns></returns>
    // POST: api/DanhMucMons
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Models.DanhMucMon>> Post(Models.DanhMucMon danhMucMon)
    {
        _database.DanhSachMon.Add(danhMucMon);
        await _database.SaveChangesAsync(HttpContext.RequestAborted);

        return Ok(danhMucMon);
    }

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // DELETE: api/DanhMucMons/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDanhMucMon(Guid id)
    {
        var danhMucMon = await _database.DanhSachMon.FindAsync(id, HttpContext.RequestAborted);
        if (danhMucMon == null) return NotFound();

        _database.DanhSachMon.Remove(danhMucMon);
        await _database.SaveChangesAsync(HttpContext.RequestAborted);

        return NoContent();
    }

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private bool DanhMucMonExists(Guid id)
    {
        return _database.DanhSachMon.Any(e => e.Id == id);
    }
}