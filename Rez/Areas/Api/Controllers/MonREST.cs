using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rez.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Rez.Areas.Api.Controllers;

/// <summary>
/// RESTful API của môn
/// </summary>
[Area("api")]
[ApiController]
[Route("/[area]/mon")]
public class MonApiController : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    private readonly Contexts.AppDbContext database;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="database"></param>
    public MonApiController(Contexts.AppDbContext database)
    {
        this.database = database;
    }

    /// <summary>
    /// Lấy môn theo id
    /// </summary>
    /// <param name="id">Mã GUID</param>
    /// <returns>Môn theo id</returns>
    /// <response code="200">Khi tìm thấy</response>
    /// <response code="400">Khi không tìm thấy</response>
    [HttpGet]
    [ProducesResponseType(typeof(Models.Mon), 200)]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await database.Mon.SingleAsync(x => x.Id == id, HttpContext.RequestAborted));
    }

    /// <summary>
    /// Tạo môn mới
    /// </summary>
    /// <param name="mon"></param>
    /// <returns></returns>
    /// <response code="200">Tạo môn mới thành công và trả về môn</response>
    [ProducesResponseType(typeof(Models.Mon), 200)]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Models.Mon mon)
    {
        await database.AddAsync(mon, HttpContext.RequestAborted);
        await database.SaveChangesAsync(HttpContext.RequestAborted);
        return Ok(mon);
    }

    /// <summary>
    /// Cập nhật môn theo id
    /// </summary>
    /// <param name="id">Guid</param>
    /// <param name="path">theo cấu trúc fast joson patch</param>
    /// <returns></returns>
    /// <response code="200">Cập nhật môn mới thành công và trả về môn</response>
    [ProducesResponseType(typeof(Models.Mon), 200)]
    [HttpPatch]
    public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<Models.Mon> path)
    {
        var mon = await database.Mon.FirstOrDefaultAsync(x => x.Id == id, HttpContext.RequestAborted);
        if (mon is not null)
        {
            path.ApplyTo(mon, ModelState);

            if (ModelState.IsValid)
            {
                await database.SaveChangesAsync(HttpContext.RequestAborted);
                return Ok(mon);
            }

            return BadRequest(ModelState);
        }
        return NotFound();
    }

    /// <summary>
    /// Xóa môn
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="402">Xóa thành công môn</response>
    /// <response code="400">không tìm thấy môn</response>
    /// <response code="500">Lỗi</response>
    [HttpDelete]
    [ProducesResponseType(402)]
    [ProducesResponseType(500)]
    [SwaggerResponseHeader(400, "", "", "", "")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            Mon mon = new() { Id = id };
            database.Entry(mon).State = EntityState.Deleted;
            int changes = await database.SaveChangesAsync(HttpContext.RequestAborted);
            if (changes == 0)
                return NotFound();
            return NoContent();
        }
        catch (Exception)
        {
            return new StatusCodeResult(500);
        }
    }

}