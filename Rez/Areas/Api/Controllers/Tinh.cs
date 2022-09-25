using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Rez.Areas.Api.Controllers;

/// <summary>
/// 
/// </summary>
[Area("Api")]
[Route("/[area]/tinh")]
[ApiController]
public class Tinh : ControllerBase
{
    private readonly Contexts.AppDbContext database;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="database"></param>
    public Tinh(Contexts.AppDbContext database)
    {
        this.database = database;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tinh"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Rez.Models.DiaChi.Tinh tinh)
    {
        Console.WriteLine("!");
        database.Add(tinh);
        await database.SaveChangesAsync(HttpContext.RequestAborted);
        return Ok(tinh);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var list = database.Tinh.Include(x => x.QuanHuyen).AsNoTracking().Select(x => new
        {
            Id = x.Id,
            Ten = x.Ten,
            QuanHuyen = x.QuanHuyen!.Select(y => new
            {
                Id = y.Id,
                Ten = y.Ten
            }).ToArray() ?? null
        }).ToArray();
        return Ok(list);
    }
}