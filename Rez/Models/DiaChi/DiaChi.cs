using System.ComponentModel.DataAnnotations;

namespace Rez.Models.DiaChi;

public class DiaChi
{
    [Key] public Guid Id { get; set; }

    public string? NoiO { get; set; }

    public Tinh? Tinh { get; set; }
    public QuanHuyen? QuanHuyen { get; set; }

    [Timestamp] public byte[]? Timestamp { get; set; }
}