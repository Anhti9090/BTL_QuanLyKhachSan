using System;
using System.Collections.Generic;

namespace Model;

public partial class GiaPhong
{
    public string MaGia { get; set; } = null!;

    public string MaLoaiPhong { get; set; } = null!;

    public string TenChinhSach { get; set; } = null!;

    public DateOnly TuNgay { get; set; }

    public DateOnly DenNgay { get; set; }

    public double GiaTheoDem { get; set; }

    public double GiaTheoGio { get; set; }

    public virtual LoaiPhong MaLoaiPhongNavigation { get; set; } = null!;
}
