using System;
using System.Collections.Generic;

namespace API.Models;

public partial class LoaiPhong
{
    public string MaLoaiPhong { get; set; } = null!;

    public string TenLoaiPhong { get; set; } = null!;

    public double GiaMacDinh { get; set; }

    public int? SoNguoiChuan { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<GiaPhong> GiaPhongs { get; set; } = new List<GiaPhong>();

    public virtual ICollection<Phong> Phongs { get; set; } = new List<Phong>();
}
