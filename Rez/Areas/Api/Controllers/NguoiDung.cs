using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rez.Contexts;
using Rez.Models;

namespace Rez.Areas.Api.Controllers;

/// <summary>
/// 
/// </summary>
[Area("Api")]
[Route("/[area]/NguoiDung")]
[ApiController]
public class NguoiDung : ControllerBase
{
    private readonly AppDbContext _context;

    public NguoiDung(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    // GET: api/NguoiDung
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var ketQua = await _context.Nguoi
            .Include(x => x.TaiKhoan)
            .Include(x => x.SoYeuLyLich)
            .AsNoTracking()
            .Select(x => new
            {
                x.Id,
                x.SoYeuLyLich!.HoVaTen,
                x.TaiKhoan!.TaiKhoanDangNhap,
                x.TaiKhoan!.ThoiGianTao,
                PhanLoai = TiengViet(x.PhanLoai)
            })
            .ToArrayAsync(HttpContext.RequestAborted);
        return Ok(ketQua);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ten"></param>
    /// <returns></returns>
    public static String TiengViet(string ten)
    {
        Dictionary<string, string> dic = new()
            { { "QuanTri", "Quản trị" }, { "GiangVien", "Giảng viên" }, { "HocVien", "Học viên" } };
        return dic[ten];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // GET: api/NguoiDung/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Nguoi>> Get(Guid id)
    {
        var nguoi = await _context.Nguoi.FindAsync(id);

        if (nguoi == null)
        {
            return NotFound();
        }

        return nguoi;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="nguoi"></param>
    /// <returns></returns>
    // PUT: api/NguoiDung/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutNguoi(Guid id, Nguoi nguoi)
    {
        if (id != nguoi.Id)
        {
            return BadRequest();
        }

        _context.Entry(nguoi).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!NguoiExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nguoi"></param>
    /// <returns></returns>
    // POST: api/NguoiDung
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Nguoi>> PostNguoi(Nguoi nguoi)
    {
        _context.Nguoi.Add(nguoi);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Get", new { id = nguoi.Id }, nguoi);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // DELETE: api/NguoiDung/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNguoi(Guid id)
    {
        try
        {
            Models.Nguoi? nguoiDung = await _context.Nguoi.Where(x => x.Id == id).Select(x => new Models.Nguoi()
            {
                Id = id,
                Timestamp = x.Timestamp
            }).FirstOrDefaultAsync(HttpContext.RequestAborted);
            
            if (nguoiDung is null)
                return NotFound();

            _context.Entry(nguoiDung).State = EntityState.Unchanged;

            _context.Remove(nguoiDung);

            int change = await _context.SaveChangesAsync(HttpContext.RequestAborted);

            if (change != 0)
                return NoContent();
            else
                return NotFound();
        }
        catch (DbUpdateConcurrencyException e)
        {
            return new StatusCodeResult(StatusCodes.Status503ServiceUnavailable);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private bool NguoiExists(Guid id)
    {
        return (_context.Nguoi?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}