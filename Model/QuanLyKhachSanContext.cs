using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class QuanLyKhachSanContext : DbContext
{
    public QuanLyKhachSanContext()
    {
    }

    public QuanLyKhachSanContext(DbContextOptions<QuanLyKhachSanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietSuDungDv> ChiTietSuDungDvs { get; set; }

    public virtual DbSet<DatPhong> DatPhongs { get; set; }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<GiaPhong> GiaPhongs { get; set; }

    public virtual DbSet<HoaDonKhachSan> HoaDonKhachSans { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=CUONG\\SQLEXPRESS;Database=QuanLyKhachSan;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietSuDungDv>(entity =>
        {
            entity.HasKey(e => e.MaChiTietDv).HasName("PK__chi_tiet__22676F303168199E");

            entity.ToTable("chi_tiet_su_dung_dv");

            entity.Property(e => e.MaChiTietDv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ma_chi_tiet_dv");
            entity.Property(e => e.MaDatPhong)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ma_dat_phong");
            entity.Property(e => e.MaDichVu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ma_dich_vu");
            entity.Property(e => e.NgaySuDung)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngay_su_dung");
            entity.Property(e => e.SoLuong).HasColumnName("so_luong");
            entity.Property(e => e.ThanhTien).HasColumnName("thanh_tien");

            entity.HasOne(d => d.MaDatPhongNavigation).WithMany(p => p.ChiTietSuDungDvs)
                .HasForeignKey(d => d.MaDatPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ct_dv_dat_phong");

            entity.HasOne(d => d.MaDichVuNavigation).WithMany(p => p.ChiTietSuDungDvs)
                .HasForeignKey(d => d.MaDichVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ct_dv_dich_vu");
        });

        modelBuilder.Entity<DatPhong>(entity =>
        {
            entity.HasKey(e => e.MaDatPhong).HasName("PK__dat_phon__9588686102ABD83E");

            entity.ToTable("dat_phong");

            entity.Property(e => e.MaDatPhong)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ma_dat_phong");
            entity.Property(e => e.GhiChu).HasColumnName("ghi_chu");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ma_khach_hang");
            entity.Property(e => e.MaPhong)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ma_phong");
            entity.Property(e => e.NgayDat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngay_dat");
            entity.Property(e => e.NgayNhanDuKien)
                .HasColumnType("datetime")
                .HasColumnName("ngay_nhan_du_kien");
            entity.Property(e => e.NgayTraDuKien)
                .HasColumnType("datetime")
                .HasColumnName("ngay_tra_du_kien");
            entity.Property(e => e.TienCoc)
                .HasDefaultValue(0.0)
                .HasColumnName("tien_coc");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("Pending")
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.DatPhongs)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dat_phong_khach_hang");

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.DatPhongs)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dat_phong_phong");
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.MaDichVu).HasName("PK__dich_vu__5ADDD345FEE3DA58");

            entity.ToTable("dich_vu");

            entity.Property(e => e.MaDichVu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ma_dich_vu");
            entity.Property(e => e.DonGia).HasColumnName("don_gia");
            entity.Property(e => e.DonViTinh)
                .HasMaxLength(50)
                .HasColumnName("don_vi_tinh");
            entity.Property(e => e.TenDichVu)
                .HasMaxLength(150)
                .HasColumnName("ten_dich_vu");
        });

        modelBuilder.Entity<GiaPhong>(entity =>
        {
            entity.HasKey(e => e.MaGia).HasName("PK__gia_phon__072D17D6C6396911");

            entity.ToTable("gia_phong");

            entity.Property(e => e.MaGia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ma_gia");
            entity.Property(e => e.DenNgay).HasColumnName("den_ngay");
            entity.Property(e => e.GiaTheoDem).HasColumnName("gia_theo_dem");
            entity.Property(e => e.GiaTheoGio).HasColumnName("gia_theo_gio");
            entity.Property(e => e.MaLoaiPhong)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ma_loai_phong");
            entity.Property(e => e.TenChinhSach)
                .HasMaxLength(150)
                .HasColumnName("ten_chinh_sach");
            entity.Property(e => e.TuNgay).HasColumnName("tu_ngay");

            entity.HasOne(d => d.MaLoaiPhongNavigation).WithMany(p => p.GiaPhongs)
                .HasForeignKey(d => d.MaLoaiPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_gia_loai_phong");
        });

        modelBuilder.Entity<HoaDonKhachSan>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__hoa_don___DBE2D9E32D783F3C");

            entity.ToTable("hoa_don_khach_san");

            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ma_hoa_don");
            entity.Property(e => e.MaDatPhong)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ma_dat_phong");
            entity.Property(e => e.NgayLap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngay_lap");
            entity.Property(e => e.PhuongThucThanhToan)
                .HasMaxLength(50)
                .HasColumnName("phuong_thuc_thanh_toan");
            entity.Property(e => e.ThueVat)
                .HasDefaultValue(0.0)
                .HasColumnName("thue_vat");
            entity.Property(e => e.TongThanhToan).HasColumnName("tong_thanh_toan");
            entity.Property(e => e.TongTienDichVu)
                .HasDefaultValue(0.0)
                .HasColumnName("tong_tien_dich_vu");
            entity.Property(e => e.TongTienPhong).HasColumnName("tong_tien_phong");

            entity.HasOne(d => d.MaDatPhongNavigation).WithMany(p => p.HoaDonKhachSans)
                .HasForeignKey(d => d.MaDatPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_hoa_don_dat_phong");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__khach_ha__C9817AF65729EF2A");

            entity.ToTable("khach_hang");

            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ma_khach_hang");
            entity.Property(e => e.CmndCccd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cmnd_cccd");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(250)
                .HasColumnName("dia_chi");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.HoTen)
                .HasMaxLength(150)
                .HasColumnName("ho_ten");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("so_dien_thoai");
        });

        modelBuilder.Entity<LoaiPhong>(entity =>
        {
            entity.HasKey(e => e.MaLoaiPhong).HasName("PK__loai_pho__07269841DB14681B");

            entity.ToTable("loai_phong");

            entity.Property(e => e.MaLoaiPhong)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ma_loai_phong");
            entity.Property(e => e.GiaMacDinh).HasColumnName("gia_mac_dinh");
            entity.Property(e => e.MoTa).HasColumnName("mo_ta");
            entity.Property(e => e.SoNguoiChuan)
                .HasDefaultValue(2)
                .HasColumnName("so_nguoi_chuan");
            entity.Property(e => e.TenLoaiPhong)
                .HasMaxLength(150)
                .HasColumnName("ten_loai_phong");
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.MaPhong).HasName("PK__phong__1BD319C9F89CC055");

            entity.ToTable("phong");

            entity.Property(e => e.MaPhong)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ma_phong");
            entity.Property(e => e.MaLoaiPhong)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ma_loai_phong");
            entity.Property(e => e.SoTang).HasColumnName("so_tang");
            entity.Property(e => e.TenPhong)
                .HasMaxLength(50)
                .HasColumnName("ten_phong");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasDefaultValue("Trống")
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.MaLoaiPhongNavigation).WithMany(p => p.Phongs)
                .HasForeignKey(d => d.MaLoaiPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_phong_loai_phong");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__user__B9BE370FC07FBD87");

            entity.ToTable("user");

            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_id");
            entity.Property(e => e.Diachi)
                .HasMaxLength(250)
                .HasColumnName("diachi");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(30)
                .HasColumnName("gioitinh");
            entity.Property(e => e.Hoten)
                .HasMaxLength(150)
                .HasColumnName("hoten");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("matkhau");
            entity.Property(e => e.Ngaysinh).HasColumnName("ngaysinh");
            entity.Property(e => e.Role)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.Taikhoan)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("taikhoan");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
