
using System.ComponentModel.DataAnnotations;

namespace Rez.Models.DiaChi;


public class DiaChi
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string? NoiO { get; set; }

    public Models.DiaChi.Tinh? Tinh { get; set; }
    public Models.DiaChi.QuanHuyen? QuanHuyen { get; set; }

    [Timestamp]
    public byte[]? Timestamp { get; set; }
}