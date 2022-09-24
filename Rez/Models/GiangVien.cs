using System.ComponentModel.DataAnnotations;

namespace Rez.Models;

/// <summary>
/// 
/// </summary>
public class GiangVien : Nguoi
{
    public string? TrinhDo { get; set; }
    public string? DonViCongTac { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public virtual ICollection<Models.Lop>? Lop { get; set; } = null!;
}