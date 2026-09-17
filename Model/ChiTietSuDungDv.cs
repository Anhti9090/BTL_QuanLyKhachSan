using System;
using System.Collections.Generic;

namespace Model;

public partial class ChiTietSuDungDv
{
    public string MaChiTietDv { get; set; } = null!;

    public string MaDatPhong { get; set; } = null!;

    public string MaDichVu { get; set; } = null!;

    public int SoLuong { get; set; }

    public double ThanhTien { get; set; }

    public DateTime? NgaySuDung { get; set; }

    public virtual DatPhong MaDatPhongNavigation { get; set; } = null!;

    public virtual DichVu MaDichVuNavigation { get; set; } = null!;
}
