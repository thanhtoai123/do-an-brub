using System.ComponentModel.DataAnnotations;

namespace Rez.Models;

public class ChiTietLich
{

    public enum TrangThaiDiemDanh
    {
        Vang,
        CoMat,
        CoPhep,
        Muon
    }
    
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public Lich Lich { get; set; }
    
    [Required]
    public HocVien HocVien { get; set; }

    public float Diem { get; set; } = 0;

    public TrangThaiDiemDanh DiemDanh { get; set; } = TrangThaiDiemDanh.Vang;
    
    public string? NhanXet { get; set; }

    [Timestamp]
    public byte[]? Timestamp { get; set; }
}