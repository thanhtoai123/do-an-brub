using System.ComponentModel.DataAnnotations;

namespace Rez.Models;

/// <summary>
/// 
/// </summary>
public class GiangVien : Nguoi
{
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public virtual ICollection<Models.Lop>? Lop { get; set; } = null!;
}