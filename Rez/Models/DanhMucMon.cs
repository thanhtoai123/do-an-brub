using System.ComponentModel.DataAnnotations;

namespace Rez.Models;

/// <summary>
/// 
/// </summary>
public class DanhMucMon
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [Required]
    public string Ten { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string? MieuTa { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public virtual ICollection<Mon>? Mon { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [Timestamp]
    public byte[]? Timestamp { get; set; }
}