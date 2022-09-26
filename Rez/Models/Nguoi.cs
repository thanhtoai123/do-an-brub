using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rez.Models;

/// <summary>
/// </summary>
public class Nguoi
{
    /// <summary>
    /// </summary>
    /// <returns></returns>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// </summary>
    /// <value></value>
    public Guid? SoYeuLyLichId { get; set; }

    /// <summary>
    /// </summary>
    /// <value></value>
    [ForeignKey(nameof(SoYeuLyLichId))]
    public virtual SoYeuLyLich.SoYeuLyLich? SoYeuLyLich { get; set; }

    public virtual TaiKhoan? TaiKhoan { get; set; }
    
    [NotMapped]
    public string PhanLoai {
        get
        {
            return this.GetType().Name;
        }
        
    }

    /// <summary>
    /// </summary>
    /// <value></value>
    [Timestamp]
    public byte[]? Timestamp { get; set; }
}