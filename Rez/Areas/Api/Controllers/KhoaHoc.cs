using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rez.Contexts;

namespace Rez.Areas.Api.Controllers;

[Area("Api")]
[Route("/[area]/KhoaHoc")]
[ApiController]
public class KhoaHoc : ControllerBase
{
    private readonly AppDbContext _database;

    public KhoaHoc(AppDbContext database)
    {
        _database = database;
    }

    // GET: api/KhoaHoc
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.KhoaHoc>>> GetKhoaHoc()
    {
        return await _database.KhoaHoc.ToListAsync();
    }

    // GET: api/KhoaHoc/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Models.KhoaHoc>> GetKhoaHoc(Guid id)
    {
        var khoaHoc = await _database.KhoaHoc.FindAsync(id);

        if (khoaHoc == null) return NotFound();

        return khoaHoc;
    }

    // PUT: api/KhoaHoc/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutKhoaHoc(Guid id, Models.KhoaHoc khoaHoc)
    {
        if (id != khoaHoc.Id) return BadRequest();

        _database.Entry(khoaHoc).State = EntityState.Modified;

        try
        {
            await _database.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!KhoaHocExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/KhoaHoc
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Models.KhoaHoc>> PostKhoaHoc(Models.KhoaHoc khoaHoc)
    {
        _database.KhoaHoc.Add(khoaHoc);
        await _database.SaveChangesAsync();

        return CreatedAtAction("GetKhoaHoc", new { id = khoaHoc.Id }, khoaHoc);
    }

    // DELETE: api/KhoaHoc/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteKhoaHoc(Guid id)
    {
        var khoaHoc = await _database.KhoaHoc.FindAsync(id);
        if (khoaHoc == null) return NotFound();

        _database.KhoaHoc.Remove(khoaHoc);
        await _database.SaveChangesAsync();

        return NoContent();
    }

    private bool KhoaHocExists(Guid id)
    {
        return _database.KhoaHoc.Any(e => e.Id == id);
    }
}