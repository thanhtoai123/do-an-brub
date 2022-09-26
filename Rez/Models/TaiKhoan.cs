using System.ComponentModel.DataAnnotations;

namespace Rez.Models;

public class TaiKhoan
{
    [Key] public Guid Id { get; set; }

    [Required] [StringLength(255)] public string TaiKhoanDangNhap { get; set; } = null!;

    public byte[]? MatKhau { get; set; }

    public DateTime ThoiGianTao { get; set; } = DateTime.Now;
    public DateTime ThoiGianDangNhapGanNhat { get; set; }

    [Timestamp] public byte[]? Timestamp { get; set; }
}