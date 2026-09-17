using System;
using System.Collections.Generic;

namespace API.Models;

public partial class DatPhong
{
    public string MaDatPhong { get; set; } = null!;

    public string MaKhachHang { get; set; } = null!;

    public string MaPhong { get; set; } = null!;

    public DateTime? NgayDat { get; set; }

    public DateTime NgayNhanDuKien { get; set; }

    public DateTime NgayTraDuKien { get; set; }

    public double? TienCoc { get; set; }

    public string? TrangThai { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietSuDungDv> ChiTietSuDungDvs { get; set; } = new List<ChiTietSuDungDv>();

    public virtual ICollection<HoaDonKhachSan> HoaDonKhachSans { get; set; } = new List<HoaDonKhachSan>();

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;

    public virtual Phong MaPhongNavigation { get; set; } = null!;
}
