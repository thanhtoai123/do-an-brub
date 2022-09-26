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
[Route("/[area]/QuanTri")]
public class QuanTri : ControllerBase
{
    private readonly AppDbContext _database;

    /// <summary>
    /// </summary>
    /// <param name="database"></param>
    public QuanTri(AppDbContext database)
    {
        _database = database;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _database.QuanTri.ToArrayAsync(HttpContext.RequestAborted));
    }

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var quanTri = await _database.QuanTri.Include(x => x.SoYeuLyLich)
            .FirstOrDefaultAsync(x => x.Id == id, HttpContext.RequestAborted);
        if (quanTri is not null) return Ok(quanTri);

        return NotFound();
    }

    /// <summary>
    /// </summary>
    /// <param name="quanTri"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Models.QuanTri quanTri)
    {
        _database.QuanTri.Attach(quanTri);
        var thayDoi = await _database.SaveChangesAsync(HttpContext.RequestAborted);
        if (thayDoi != 0)
        {
            quanTri.TaoTaiKhoan();
            await _database.SaveChangesAsync();
        }
        else
        {
            Conflict();
        }

        return Ok(quanTri);
    }

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        Models.QuanTri quanTri = new() { Id = id };
        _database.Entry(quanTri).State = EntityState.Deleted;
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
    public async Task<IActionResult> Update(Guid id, [FromBody] JsonPatchDocument<Models.QuanTri> patch)
    {
        var quanTri = await _database.QuanTri.FirstOrDefaultAsync(x => x.Id == id, HttpContext.RequestAborted);
        if (quanTri is not null)
        {
            patch.ApplyTo(quanTri, ModelState);
            if (ModelState.IsValid) return Ok(quanTri);

            return BadRequest(ModelState);
        }

        return NotFound();
    }
}