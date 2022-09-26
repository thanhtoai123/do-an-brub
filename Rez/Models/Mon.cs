using System.ComponentModel.DataAnnotations;

namespace Rez.Models;

/// <summary>
/// </summary>
public class Mon
{
    /// <summary>
    /// </summary>
    /// <returns></returns>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// </summary>
    /// <value></value>
    [Required]
    public string Ten { get; set; } = null!;

    /// <summary>
    /// </summary>
    /// <value></value>
    public string? MieuTa { get; set; }

    /// <summary>
    /// </summary>
    /// <value></value>
    public virtual ICollection<GiangVien>? GiangVien { get; set; }

    /// <summary>
    /// </summary>
    /// <value></value>
    public virtual ICollection<DanhMucMon>? DanhMucMon { get; set; }

    /// <summary>
    /// </summary>
    public virtual ICollection<KhoaHoc>? KhoaHoc { get; set; }

    /// <summary>
    /// </summary>
    /// <value></value>
    [Timestamp]
    public byte[]? Timestamp { get; set; } = null!;
}