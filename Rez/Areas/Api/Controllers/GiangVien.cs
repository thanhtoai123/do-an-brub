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
[Route("/[area]/[controller]")]
public class GiangVien : ControllerBase
{
    private readonly Contexts.AppDbContext database;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="database"></param>
    public GiangVien(Contexts.AppDbContext database)
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
        return Ok(await database.GiangVien.ToArrayAsync(HttpContext.RequestAborted));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var giangVien = await database.GiangVien.Include(x => x.SoYeuLyLich).FirstOrDefaultAsync(x => x.Id == id, HttpContext.RequestAborted);
        if (giangVien is not null)
        {
            return Ok(giangVien);
        }
        return NotFound();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post(Models.GiangVien model)
    {
        if (model.Lop is not null)
        {
            string[] ten = model.Lop.Select(x => x.Ten).ToArray();
            ICollection<Models.Lop> monMoi = new HashSet<Models.Lop>();
            ten.ForAll(x =>
            {
                var lop = database.Lop.FirstOrDefault(y => y.Ten == x);
                if (lop is not null)
                {
                    lop.GiangVien = null;
                    database.Entry(lop).State = EntityState.Unchanged;
                    monMoi.Add(lop);
                }
                else
                    monMoi.Add(model.Lop.First(y => y.Ten == x));
            });
            model.Lop = monMoi;
        }

        await database.AddAsync(model, HttpContext.RequestAborted);
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
        Models.GiangVien giangVien = new() { Id = id };
        database.Entry(giangVien).State = EntityState.Deleted;
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
    public async Task<IActionResult> Update(Guid id, [FromBody] JsonPatchDocument<Models.GiangVien> patch)
    {
        var giangVien = await database.GiangVien.FirstOrDefaultAsync(x => x.Id == id, HttpContext.RequestAborted);
        if (giangVien is not null)
        {
            patch.ApplyTo(giangVien, ModelState);
            if (ModelState.IsValid)
            {
                return Ok(giangVien);
            }

            return BadRequest(ModelState);
        }
        return NotFound();
    }
}