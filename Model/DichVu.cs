using System;
using System.Collections.Generic;

namespace Model;

public partial class DichVu
{
    public string MaDichVu { get; set; } = null!;

    public string TenDichVu { get; set; } = null!;

    public double DonGia { get; set; }

    public string? DonViTinh { get; set; }

    public virtual ICollection<ChiTietSuDungDv> ChiTietSuDungDvs { get; set; } = new List<ChiTietSuDungDv>();
}
