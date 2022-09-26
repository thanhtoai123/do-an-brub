using System.ComponentModel.DataAnnotations;

namespace Rez.Models.DiaChi;

public class QuanHuyen
{
    [Key]
    [Required(ErrorMessage = "Vui lòng chọn quận/huyện")]
    public Guid Id { get; set; }

    public string? Ten { get; set; }

    public virtual Tinh? Tinh { get; set; }

    [Timestamp] public byte[]? Timestamp { get; set; }
}