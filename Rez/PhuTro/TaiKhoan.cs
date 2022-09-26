using Rez.Models;

namespace Rez.PhuTro;

public static class TaiKhoan
{
    public static void TaoTaiKhoan(this Nguoi nguoi, string? matKhau = null)
    {
        if (nguoi.SoYeuLyLich is null)
            throw new NullReferenceException("Không có sơ yếu lý lịch");

        if (nguoi.SoYeuLyLich.HoVaTen is null)
            throw new Exception("Chưa đặt tên");

        matKhau ??= string.Format("{0:ddMMyyyy}", nguoi.SoYeuLyLich.SinhNgay) + string.Join("",
            nguoi.SoYeuLyLich.HoVaTen.Trim().LoaiBoDau().Split(" ")
                .Select(x => x[0].ToString().ToUpper() + x.Substring(1))).ToLower();

        nguoi.TaiKhoan = new Models.TaiKhoan
        {
            TaiKhoanDangNhap = nguoi.SoYeuLyLich.HoVaTen.ToLower().LoaiBoDau().Replace(" ", "") +
                               string.Format("{0:ddMMyyyy}", nguoi.SoYeuLyLich.SinhNgay),
            MatKhau = MatKhau.MaHoaMatKhau(matKhau)
        };
    }
}