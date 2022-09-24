using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rez.Models;

/// <summary>
/// 
/// </summary>
public class HocVien : Nguoi
{
    public String? Truong { get; set; }
    public String? PhuHuynh { get; set; }

    public virtual ICollection<Models.Lop>? Lop { get; set; } = null!;
}