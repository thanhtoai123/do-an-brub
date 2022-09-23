using Microsoft.EntityFrameworkCore;
using Rez.Models;

namespace Rez.Contexts;

/// <summary>
/// 
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Models.HocVien>(enity =>
        {
            enity.HasIndex(x => x.SoYeuLyLichId).IsUnique();
        });

        builder.Entity<Models.Mon>(entity =>
        {
            entity.HasIndex(x => x.Ten).IsUnique();
            entity.HasMany(x => x.DanhMucMon).WithMany(x => x.Mon);
        });

        builder.Entity<Models.DanhMucMon>(entity =>
        {
            entity.HasMany(x => x.Mon).WithMany(x => x.DanhMucMon);
        });

        builder.Entity<Models.KhoaHoc>(entity =>
        {
            entity.HasIndex(x => x.Ten).IsUnique();
        });

        builder.Entity<Models.Lop>(entity =>
        {
            entity.HasIndex(x => x.Ten).IsUnique();
        });

        builder.Entity<Models.DiemDanh>(entity =>
        {
            entity.HasIndex(nameof(Models.DiemDanh.HocVienId),
                            nameof(Models.DiemDanh.LichId))
                  .IsUnique();
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public DbSet<Models.Mon> Mon { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public DbSet<Models.Nguoi> Nguoi { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public DbSet<Models.HocVien> HocVien { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public DbSet<Models.GiangVien> GiangVien { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public DbSet<Models.SoYeuLyLich.SoYeuLyLich> SoYeuLyLich { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public DbSet<Models.SoYeuLyLich.ChungMinh> ChungMinh { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public DbSet<Models.SoYeuLyLich.QuanHeGiaDinh> QuanHeGiaDinh { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public DbSet<Models.SoYeuLyLich.QuaTrinhCongTac> QuaTrinhCongTac { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public DbSet<Models.SoYeuLyLich.QuaTrinhDaoTao> QuaTrinhDaoTao { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public DbSet<Models.DanhMucMon> DanhSachMon { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public DbSet<Rez.Models.KhoaHoc> KhoaHoc { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    public DbSet<Models.Lop> Lop { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    public DbSet<Rez.Models.Lich> Lich { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    public DbSet<Rez.Models.DiemDanh> DienDanh { get; set; }
}