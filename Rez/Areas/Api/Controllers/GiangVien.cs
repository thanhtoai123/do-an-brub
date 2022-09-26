using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rez.Contexts;
using Rez.PhuTro;

namespace Rez.Areas.Api.Controllers;

/// <summary>
/// </summary>
[Area("Api")]
[ApiController]
[Route("/[area]/[controller]")]
public class GiangVien : ControllerBase
{
    private readonly AppDbContext _database;

    /// <summary>
    /// </summary>
    /// <param name="database"></param>
    public GiangVien(AppDbContext database)
    {
        _database = database;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _database.GiangVien.ToArrayAsync(HttpContext.RequestAborted));
    }

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var giangVien = await _database.GiangVien.Include(x => x.SoYeuLyLich)
            .FirstOrDefaultAsync(x => x.Id == id, HttpContext.RequestAborted);
        if (giangVien is not null) return Ok(giangVien);
        return NotFound();
    }

    /// <summary>
    /// </summary>
    /// <param name="giangVien"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post(Models.GiangVien giangVien)
    {
        _database.GiangVien.Attach(giangVien);
        var thayDoi = await _database.SaveChangesAsync(HttpContext.RequestAborted);
        if (thayDoi != 0)
        {
            giangVien.TaoTaiKhoan();
            await _database.SaveChangesAsync();
        }
        else
        {
            Conflict();
        }

        return Ok(giangVien);
    }

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        Models.GiangVien giangVien = new() { Id = id };
        _database.Entry(giangVien).State = EntityState.Deleted;
        var changes = await _database.SaveChangesAsync(HttpContext.RequestAborted);
        if (changes == 0) return NotFound();

        return NoContent();
    }

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut]
    public IActionResult Put(Guid id)
    {
        return StatusCode(StatusCodes.Status405MethodNotAllowed);
    }

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="patch"></param>
    /// <returns></returns>
    [HttpPatch]
    public async Task<IActionResult> Update(Guid id, [FromBody] JsonPatchDocument<Models.GiangVien> patch)
    {
        var giangVien = await _database.GiangVien.FirstOrDefaultAsync(x => x.Id == id, HttpContext.RequestAborted);
        if (giangVien is not null)
        {
            patch.ApplyTo(giangVien, ModelState);
            if (ModelState.IsValid) return Ok(giangVien);

            return BadRequest(ModelState);
        }

        return NotFound();
    }
}