using System;
using System.Collections.Generic;

namespace Model;

public partial class Phong
{
    public string MaPhong { get; set; } = null!;

    public string MaLoaiPhong { get; set; } = null!;

    public string TenPhong { get; set; } = null!;

    public int SoTang { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<DatPhong> DatPhongs { get; set; } = new List<DatPhong>();

    public virtual LoaiPhong MaLoaiPhongNavigation { get; set; } = null!;
}
