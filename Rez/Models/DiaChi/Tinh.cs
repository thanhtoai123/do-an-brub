using System.ComponentModel.DataAnnotations;

namespace Rez.Models.DiaChi;

public class Tinh
{
    [Key]
    [Required(ErrorMessage = "Vui lòng chọn tỉnh/thành phố")]
    public Guid Id { get; set; }

    public string? Ten { get; set; }

    public virtual ICollection<QuanHuyen>? QuanHuyen { get; set; }

    [Timestamp] public byte[]? Timestamp { get; set; }
}