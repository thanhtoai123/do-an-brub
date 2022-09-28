using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rez.Models;

public class TaiKhoan
{
    [Key] public Guid Id { get; set; }

    [Required] [StringLength(255)] public string TaiKhoanDangNhap { get; set; } = null!;

    public byte[]? MatKhau { get; set; }

    public DateTime ThoiGianTao { get; set; } = DateTime.Now;
    public DateTime ThoiGianDangNhapGanNhat { get; set; }

    public Guid NguoiDungId { get; set; }
    [ForeignKey(nameof(NguoiDungId))]
    public virtual Nguoi NguoiDung { get; set; } = null!;

    [Timestamp] public byte[]? Timestamp { get; set; }
}