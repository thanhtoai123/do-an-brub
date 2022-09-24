
using System.ComponentModel.DataAnnotations;

namespace Rez.Models.DiaChi;

public class Tinh
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string? Ten { get; set; }

    public virtual ICollection<QuanHuyen>? QuanHuyen { get; set; }

    [Timestamp]
    public byte[]? Timestamp { get; set; }
}