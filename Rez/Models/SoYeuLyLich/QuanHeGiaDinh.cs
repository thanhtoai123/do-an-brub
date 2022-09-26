using System.ComponentModel.DataAnnotations;

namespace Rez.Models.SoYeuLyLich;

/// <summary>
/// </summary>
public class QuanHeGiaDinh
{
    /// <summary>
    /// </summary>
    /// <value></value>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// </summary>
    /// <value></value>
    public string? CoQuanCongTac { get; set; }

    /// <summary>
    /// </summary>
    /// <value></value>
    public virtual SoYeuLyLich? SoYeuLyLich { get; set; }

    /// <summary>
    /// </summary>
    /// <value></value>
    [Timestamp]
    public byte[] Timestamp { get; set; } = null!;
}