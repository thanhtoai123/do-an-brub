using System.ComponentModel.DataAnnotations;

namespace Rez.Models.DiaChi;


public class QuanHuyen
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string? Ten { get; set; }
    
    public virtual Tinh? Tinh { get; set; }

    [Timestamp]
    public byte[]? Timestamp { get; set; }
}