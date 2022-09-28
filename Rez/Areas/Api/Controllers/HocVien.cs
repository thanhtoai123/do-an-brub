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
[Route("/[area]/hocvien")]
public class HocVien : ControllerBase
{
    private readonly AppDbContext _database;

    /// <summary>
    /// </summary>
    /// <param name="database"></param>
    public HocVien(AppDbContext database)
    {
        _database = database;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var danhSach = await _database.HocVien.Include(x => x.SoYeuLyLich).AsNoTracking()
            .ToArrayAsync(HttpContext.RequestAborted);
        return Ok(danhSach);
    }

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var hocVien = await _database.HocVien.Include(x => x.SoYeuLyLich)
            .FirstOrDefaultAsync(x => x.Id == id, HttpContext.RequestAborted);
        if (hocVien is null)
            return NotFound();
        return Ok(hocVien);
    }

    /// <summary>
    /// </summary>
    /// <param name="hocVien"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post(Models.HocVien hocVien)
    {
        _database.HocVien.Attach(hocVien);

        int thayDoi;
        thayDoi = await _database.SaveChangesAsync(HttpContext.RequestAborted);

        if (thayDoi != 0)
        {
            hocVien.TaoTaiKhoan();
            await _database.SaveChangesAsync();
        }
        else
        {
            Conflict();
        }

        return Ok(hocVien);
    }

    /// <summary>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
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
    public IActionResult Update(Guid id, [FromBody] JsonPatchDocument patch)
    {
        return Ok();
    }
}