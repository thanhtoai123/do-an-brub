using System.ComponentModel.DataAnnotations;

namespace Rez.Models;

/// <summary>
/// </summary>
public class Lop
{
    /// <summary>
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    [Required] public string Ten { get; set; } = null!;

    /// <summary>
    /// </summary>
    public virtual KhoaHoc? KhoaHoc { get; set; }

    /// <summary>
    /// </summary>
    public virtual ICollection<HocVien>? HocVien { get; set; }

    /// <summary>
    /// </summary>
    public virtual GiangVien? GiangVien { get; set; }

    /// <summary>
    /// </summary>
    [Timestamp]
    public byte[]? Timestamp { get; set; }
}