using Microsoft.EntityFrameworkCore;
using Rez.Models;
using Rez.Models.DiaChi;
using Rez.Models.SoYeuLyLich;

namespace Rez.Contexts;

/// <summary>
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        SavingChanges += (sender, e) => { };
    }

    /// <summary>
    /// </summary>
    public DbSet<Mon> Mon { get; set; } = null!;

    /// <summary>
    /// </summary>
    public DbSet<Nguoi> Nguoi { get; set; } = null!;

    /// <summary>
    /// </summary>
    public DbSet<HocVien> HocVien { get; set; } = null!;

    /// <summary>
    /// </summary>
    public DbSet<GiangVien> GiangVien { get; set; } = null!;

    /// <summary>
    /// </summary>
    public DbSet<SoYeuLyLich> SoYeuLyLich { get; set; } = null!;

    /// <summary>
    /// </summary>
    public DbSet<ChungMinh> ChungMinh { get; set; } = null!;

    /// <summary>
    /// </summary>
    public DbSet<QuanHeGiaDinh> QuanHeGiaDinh { get; set; } = null!;

    /// <summary>
    /// </summary>
    public DbSet<QuaTrinhCongTac> QuaTrinhCongTac { get; set; } = null!;

    /// <summary>
    /// </summary>
    public DbSet<QuaTrinhDaoTao> QuaTrinhDaoTao { get; set; } = null!;

    /// <summary>
    /// </summary>
    public DbSet<DanhMucMon> DanhSachMon { get; set; } = null!;

    /// <summary>
    /// </summary>
    public DbSet<KhoaHoc> KhoaHoc { get; set; } = null!;

    /// <summary>
    /// </summary>
    public DbSet<Lop> Lop { get; set; } = null!;

    /// <summary>
    /// </summary>
    public DbSet<Lich> Lich { get; set; } = null!;

    /// <summary>
    /// </summary>
    public DbSet<DiemDanh> DienDanh { get; set; } = null!;

    /// <summary>
    /// </summary>
    public DbSet<DiaChi> DiaChi { get; set; } = null!;

    /// <summary>
    /// </summary>
    public DbSet<Tinh> Tinh { get; set; } = null!;

    /// <summary>
    /// </summary>
    public DbSet<QuanHuyen> QuanHuyen { get; set; } = null!;

    /// <summary>
    /// </summary>
    public DbSet<QuanTri> QuanTri { get; set; } = null!;

    /// <summary>
    /// </summary>
    public DbSet<TaiKhoan> TaiKhoan { get; set; } = null!;

    /// <summary>
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<HocVien>(enity => { enity.HasIndex(x => x.SoYeuLyLichId).IsUnique(); });

        builder.Entity<Mon>(entity =>
        {
            entity.HasIndex(x => x.Ten).IsUnique();
            entity.HasMany(x => x.DanhMucMon).WithMany(x => x.Mon);
        });

        builder.Entity<DanhMucMon>(entity => { entity.HasMany(x => x.Mon).WithMany(x => x.DanhMucMon); });

        builder.Entity<KhoaHoc>(entity => { entity.HasIndex(x => x.Ten).IsUnique(); });

        builder.Entity<Lop>(entity => { entity.HasIndex(x => x.Ten).IsUnique(); });

        builder.Entity<DiemDanh>(entity =>
        {
            entity.HasIndex(nameof(DiemDanh.HocVienId),
                    nameof(DiemDanh.LichId))
                .IsUnique();
        });

        builder.Entity<Tinh>(entity => { entity.HasIndex(x => x.Ten).IsUnique(); });

        builder.Entity<TaiKhoan>(entity => { entity.HasIndex(x => x.TaiKhoanDangNhap).IsUnique(); });
    }
}