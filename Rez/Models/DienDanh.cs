using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rez.Models;

public class DiemDanh
{
    [Key] public Guid Id { get; set; }

    [Required] public Guid HocVienId { get; set; }

    [Required] public Guid LichId { get; set; }

    [ForeignKey(nameof(HocVienId))] public virtual HocVien HocVien { get; set; } = null!;

    [ForeignKey(nameof(LichId))] public virtual Lich Lich { get; set; } = null!;

    public DateTime ThoiDiemDiemDanh { get; set; } = DateTime.Now;

    [Timestamp] public byte[]? Timestamp { get; set; }
}