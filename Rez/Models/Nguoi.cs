using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rez.Models;

/// <summary>
/// 
/// </summary>
public class Nguoi
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public Guid? SoYeuLyLichId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [ForeignKey(nameof(SoYeuLyLichId))]
    public virtual SoYeuLyLich.SoYeuLyLich? SoYeuLyLich { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public string SoDienThoai { get; set; } = String.Empty;
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = String.Empty;

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    [Timestamp]
    public byte[]? Timestamp { get; set; } = null!;
}