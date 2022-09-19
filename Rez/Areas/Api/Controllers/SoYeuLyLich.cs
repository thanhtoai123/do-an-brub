using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rez.Models.SoYeuLyLich;

namespace Rez.Areas.Api.Controllers;

/// <summary>
/// 
/// </summary>
[Area("api")]
[ApiController]
[Route("/[area]/[controller]")]
public class SoYeuLyLich : ControllerBase
{
    private readonly Contexts.AppDbContext database;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="database"></param>
    public SoYeuLyLich(Contexts.AppDbContext database)
    {
        this.database = database;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="soYeuLyLich"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Post([FromBody] Models.SoYeuLyLich.SoYeuLyLich soYeuLyLich)
    {
        database.Add(soYeuLyLich);

        database.SaveChanges();

        return Ok(soYeuLyLich);
    }
}