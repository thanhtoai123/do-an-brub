using AutoMapper.Internal;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rez.Models;

namespace Rez.Areas.Api.Controllers;

/// <summary>
/// 
/// </summary>
[Area("Api")]
[ApiController]
[Route("/[area]/QuanTri")]
public class QuanTri : ControllerBase
{
    private readonly Contexts.AppDbContext database;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="database"></param>
    public QuanTri(Contexts.AppDbContext database)
    {
        this.database = database;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await database.QuanTri.ToArrayAsync(HttpContext.RequestAborted));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var quanTri = await database.QuanTri.Include(x => x.SoYeuLyLich).FirstOrDefaultAsync(x => x.Id == id, HttpContext.RequestAborted);
        if (quanTri is not null)
        {
            return Ok(quanTri);
        }
        return NotFound();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]Models.QuanTri model)
    {
        database.QuanTri.Attach(model);
        await database.SaveChangesAsync(HttpContext.RequestAborted);
        return Ok(model);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        Models.QuanTri quanTri = new() { Id = id };
        database.Entry(quanTri).State = EntityState.Deleted;
        int changes = await database.SaveChangesAsync(HttpContext.RequestAborted);
        if (changes == 0)
        {
            return NotFound();
        }

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
    public async Task<IActionResult> Update(Guid id, [FromBody] JsonPatchDocument<Models.QuanTri> patch)
    {
        var quanTri = await database.QuanTri.FirstOrDefaultAsync(x => x.Id == id, HttpContext.RequestAborted);
        if (quanTri is not null)
        {
            patch.ApplyTo(quanTri, ModelState);
            if (ModelState.IsValid)
            {
                return Ok(quanTri);
            }

            return BadRequest(ModelState);
        }
        return NotFound();
    }
}