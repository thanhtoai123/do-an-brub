using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Rez.Areas.Api.Controllers;

[Area("Api")]
[Route("/[area]/tinh")]
[ApiController]
public class Tinh : ControllerBase
{
    private readonly Contexts.AppDbContext database;

    public Tinh(Contexts.AppDbContext database)
    {
        this.database = database;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Rez.Models.DiaChi.Tinh tinh)
    {
        Console.WriteLine("!");
        database.Add(tinh);
        await database.SaveChangesAsync(HttpContext.RequestAborted);
        return Ok(tinh);
    }

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