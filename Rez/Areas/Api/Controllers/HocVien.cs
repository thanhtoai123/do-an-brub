using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Rez.Areas.Api.Controllers;


/// <summary>
/// 
/// </summary>
[Area("Api")]
[ApiController]
[Route("/[area]/hocvien")]
public class HocVien : ControllerBase
{
    private readonly Contexts.AppDbContext database;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="database"></param>
    public HocVien(Contexts.AppDbContext database)
    {
        this.database = database;
    }

    public async Task<IActionResult> GetAll()
    {
        var danhSach = await database.HocVien.Include(x => x.SoYeuLyLich).AsNoTracking().ToArrayAsync(HttpContext.RequestAborted);
        if (danhSach is null)
            return NotFound();
        return Ok(danhSach);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        Models.HocVien? hocVien = await database.HocVien.Include(x => x.SoYeuLyLich).FirstOrDefaultAsync(x => x.Id == id, HttpContext.RequestAborted);
        if (hocVien is null)
            return NotFound();
        return Ok(hocVien);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post(Models.HocVien model)
    {
        database.Add(model);

        int change = await database.SaveChangesAsync(HttpContext.RequestAborted);

        if(change == 0)
            return Conflict();

        return Ok(model);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        return NoContent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut]
    public IActionResult Put(Guid id)
    {
        return StatusCode(StatusCodes.Status405MethodNotAllowed);
    }

    /// <summary>
    /// 
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