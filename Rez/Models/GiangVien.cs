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
    public virtual ICollection<Mon>? Mon { get; set; } = null!;
}