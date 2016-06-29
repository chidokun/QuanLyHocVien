// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "BangDiem.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System.Linq;
using DataAccess;
using static BusinessLogic.GlobalSettings;
using System;

namespace BusinessLogic
{
    /// <summary>
    /// Mô tả chi tiết bảng điểm trên giao diện
    /// </summary>
    public struct BangDiemDetail
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string TenKH { get; set; }
        public DateTime? NgayBD { get; set; }
        public DateTime? NgayKT { get; set; }
        public int? SiSo { get; set; }
        public bool? DangMo { get; set; }
        public string MaHV { get; set; }
        public string TenHV { get; set; }
        public int DiemNghe { get; set; }
        public int DiemNoi { get; set; }
        public int DiemDoc { get; set; }
        public int DiemViet { get; set; }
        public double DiemTrungBinh { get; set; }
    }

    public struct BangDiemTrungBinh
    {
        public string MaHV { get; set; }
        public string TenHV { get; set; }
        public int DiemNghe { get; set; }
        public int DiemNoi { get; set; }
        public int DiemDoc { get; set; }
        public int DiemViet { get; set; }
        public double DiemTrungBinh { get; set; }
    }

    public static class BangDiem
    {
        /// <summary>
        /// Lấy chi tiết của một bảng điểm
        /// </summary>
        /// <param name="maHV">Mã học viên</param>
        /// <param name="maLop">Mã lớp</param>
        /// <returns></returns>
        public static BangDiemDetail SelectDetail(string maHV, string maLop)
        {
            return (from p in Database.BANGDIEMs
                    where p.MaLop == maLop && p.MaHV == maHV
                    select new BangDiemDetail()
                    {
                        MaLop = p.MaLop,
                        TenLop = p.LOPHOC.TenLop,
                        TenKH = p.LOPHOC.KHOAHOC.TenKH,
                        NgayBD = p.LOPHOC.NgayBD,
                        NgayKT = p.LOPHOC.NgayKT,
                        SiSo = p.LOPHOC.SiSo,
                        DangMo = p.LOPHOC.DangMo,
                        MaHV = p.MaHV,
                        TenHV = p.HOCVIEN.TenHV,
                        DiemNghe = (int)p.DiemNghe,
                        DiemNoi = (int)p.DiemNoi,
                        DiemDoc = (int)p.DiemDoc,
                        DiemViet = (int)p.DiemViet,
                        DiemTrungBinh = (int)p.DiemNghe * (double)p.LOPHOC.KHOAHOC.HeSoNghe / 100 +
                                        (int)p.DiemNoi * (double)p.LOPHOC.KHOAHOC.HeSoNoi / 100 +
                                        (int)p.DiemDoc * (double)p.LOPHOC.KHOAHOC.HeSoDoc / 100 +
                                        (int)p.DiemViet * (double)p.LOPHOC.KHOAHOC.HeSoViet / 100
                    }).Single();
        }

        /// <summary>
        /// Chọn một bảng điểm
        /// </summary>
        /// <param name="maHV">Mã học viên</param>
        /// <param name="maLop">Mã lớp</param>
        /// <returns></returns>
        public static BANGDIEM Select(string maHV, string maLop)
        {
            return (from p in Database.BANGDIEMs
                    where p.MaLop == maLop && p.MaHV == maHV
                    select p).Single();
        }

        /// <summary>
        /// Chọn danh sách học viên trong một lớp
        /// </summary>
        /// <param name="maLop">Mã lớp</param>
        /// <returns></returns>
        public static object SelectDSHV(string maLop)
        {
            return (from p in Database.BANGDIEMs
                    where p.MaLop == maLop
                    select new
                    {
                        MaHV = p.MaHV,
                        TenHV = p.HOCVIEN.TenHV,
                        GioiTinhHV = p.HOCVIEN.GioiTinhHV
                    }).ToList();
        }

        /// <summary>
        /// Lấy danh sách lớp của học viên
        /// </summary>
        /// <param name="maHV">Mã học viên</param>
        /// <returns></returns>
        public static object SelectDSLop(string maHV, DateTime? tuNgay = null, DateTime? denNgay = null, string maKH = null)
        {
            return (from p in Database.BANGDIEMs
                    where p.MaHV == maHV &&
                        (tuNgay == null ? true : p.LOPHOC.NgayBD >= tuNgay) &&
                        (denNgay == null ? true : p.LOPHOC.NgayKT <= denNgay) &&
                        (maKH == null ? true : p.LOPHOC.MaKH == maKH)
                    select new
                    {
                        MaLop = p.MaLop,
                        TenLop = p.LOPHOC.TenLop,
                    }).ToList();
        }

        /// <summary>
        /// Lấy bảng điểm trung bình của lớp
        /// </summary>
        /// <param name="maLop">Mã lớp</param>
        /// <returns></returns>
        public static object SelectBangDiemLop(string maLop)
        {
            return (from p in Database.BANGDIEMs
                    where p.MaLop == maLop
                    select new BangDiemTrungBinh()
                    {
                        MaHV = p.MaHV,
                        TenHV = p.HOCVIEN.TenHV,
                        DiemNghe = (int)p.DiemNghe,
                        DiemNoi = (int)p.DiemNoi,
                        DiemDoc = (int)p.DiemDoc,
                        DiemViet = (int)p.DiemViet,
                        DiemTrungBinh = (int)p.DiemNghe * (double)p.LOPHOC.KHOAHOC.HeSoNghe / 100 +
                                        (int)p.DiemNoi * (double)p.LOPHOC.KHOAHOC.HeSoNoi / 100 +
                                        (int)p.DiemDoc * (double)p.LOPHOC.KHOAHOC.HeSoDoc / 100 +
                                        (int)p.DiemViet * (double)p.LOPHOC.KHOAHOC.HeSoViet / 100
                    }).ToList();
        }

        /// <summary>
        /// Cập nhật bảng điểm
        /// </summary>
        /// <param name="b"></param>
        public static void Update(BANGDIEM b)
        {
            var temp = Select(b.MaHV, b.MaLop);

            temp.DiemNghe = b.DiemNghe;
            temp.DiemNoi = b.DiemNoi;
            temp.DiemDoc = b.DiemDoc;
            temp.DiemViet = b.DiemViet;

            Database.SubmitChanges();
        }
    }
}
