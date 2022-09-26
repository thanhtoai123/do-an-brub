using System.ComponentModel.DataAnnotations;

namespace Rez.Models;

/// <summary>
/// </summary>
public class GiangVien : Nguoi
{
    [Required(ErrorMessage = "Vui lòng chọn trình độ")]
    public string? TrinhDo { get; set; }

    [Required(ErrorMessage = "Vui lòng điền đơn vị công tác")]
    public string? DonViCongTac { get; set; }

    /// <summary>
    /// </summary>
    /// <value></value>
    public virtual ICollection<Lop>? Lop { get; set; } = null!;
}