using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rez.Models;

/// <summary>
/// 
/// </summary>
public class HocVien : Nguoi
{
}

/// <summary>
/// 
/// </summary>
public interface IHocVien
{
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public Guid Id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string HoTen { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public DateTime NgaySinh { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string SoDienThoai { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string Email { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string DiaChi { get; set; }
}