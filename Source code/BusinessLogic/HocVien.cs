// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "HocVien.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using static BusinessLogic.GlobalSettings;

namespace BusinessLogic
{
    public class HocVien
    {
        /// <summary>
        /// Chọn tất cả
        /// </summary>
        /// <returns></returns>
        public object SelectAll()
        {
            var result = from p in GlobalSettings.Database.HOCVIENs
                         select new { MaHV = p.MaHV, TenHV = p.TenHV, NgaySinh = p.NgaySinh, GioiTinhHV = p.GioiTinhHV, SdtHV = p.SdtHV, EmailHV = p.EmailHV };

            return result.ToList();
        }

        public object SelectAllResult()
        {
            var result = from p in GlobalSettings.Database.HOCVIENs
                         where p.MaLoaiHV == "LHV00"
                         select new { MaHV = p.MaHV, TenHV = p.TenHV, NgaySinh = p.NgaySinh, GioiTinhHV = p.GioiTinhHV };

            return result.ToList();
        }

        public object SelectResultMaHV(string maHV)
        {
            var result = from p in GlobalSettings.Database.HOCVIENs
                         where p.MaHV.Contains(maHV) && p.MaLoaiHV == "LHV00"
                         select new { MaHV = p.MaHV, TenHV = p.TenHV, NgaySinh = p.NgaySinh, GioiTinhHV = p.GioiTinhHV };

            return result.ToList();
        }

        public object SelectResultTenHV(string tenHV)
        {
            var result = from p in GlobalSettings.Database.HOCVIENs
                         where p.TenHV.Contains(tenHV) && p.MaLoaiHV == "LHV00"
                         select new { MaHV = p.MaHV, TenHV = p.TenHV, NgaySinh = p.NgaySinh, GioiTinhHV = p.GioiTinhHV };

            return result.ToList();
        }


        /// <summary>
        /// Chọn một học viên
        /// </summary>
        /// <param name="maHV">Mã học viên</param>
        /// <returns></returns>
        public HOCVIEN Select(string maHV)
        {
            return (from p in GlobalSettings.Database.HOCVIENs
                    where p.MaHV == maHV
                    select p).Single();
        }

        /// <summary>
        /// Thêm một học viên
        /// </summary>
        /// <param name="hocVien">Học viên cần thêm</param>
        public void Insert(HOCVIEN hocVien, TAIKHOAN taiKhoan = null)
        {
            if (taiKhoan != null)
                Database.TAIKHOANs.InsertOnSubmit(taiKhoan);
            Database.HOCVIENs.InsertOnSubmit(hocVien);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Cập nhật một học viên
        /// </summary>
        /// <param name="hocVien">Học viên cần cập nhật</param>
        /// <param name="taiKhoan">Tài khoản cần thêm mới</param>
        public void Update(HOCVIEN hocVien, TAIKHOAN taiKhoan = null)
        {
            if (taiKhoan != null)
            {
                Database.TAIKHOANs.InsertOnSubmit(taiKhoan);
                Database.SubmitChanges();
            }

            var temp = Select(hocVien.MaHV);
            temp.TenHV = hocVien.TenHV;
            temp.NgaySinh = hocVien.NgaySinh;
            temp.GioiTinhHV = hocVien.GioiTinhHV;
            temp.DiaChi = hocVien.DiaChi;
            temp.SdtHV = hocVien.SdtHV;
            temp.EmailHV = hocVien.EmailHV;
            temp.MaLoaiHV = hocVien.MaLoaiHV;
            temp.TenDangNhap = hocVien.TenDangNhap != null ? hocVien.TenDangNhap : null;

            Database.SubmitChanges();
        }

        /// <summary>
        /// Xóa một học viên
        /// </summary>
        /// <param name="maHV">Mã học viên cần xóa</param>
        public void Delete(string maHV)
        {
            var temp = (from p in GlobalSettings.Database.HOCVIENs
                        where p.MaHV == maHV
                        select p).Single();

            Database.HOCVIENs.DeleteOnSubmit(temp);
            Database.SubmitChanges();

            string tenDN = temp.TenDangNhap;
            TaiKhoan tk = new TaiKhoan();
            if (tenDN != null)
                tk.Delete(tenDN);
        }

        /// <summary>
        /// Tự động sinh mã học viên
        /// </summary>
        /// <returns></returns>
        public string AutoGenerateId()
        {
            string result = "HV" + DateTime.Now.ToString("yyMMdd");
            var temp = from p in GlobalSettings.Database.HOCVIENs
                       where p.MaHV.StartsWith(result)
                       select p.MaHV;
            int max = 0;

            foreach (var i in temp)
            {
                int j = int.Parse(i.Substring(8, 2));
                if (j > max) max = j;
            }

            return string.Format("{0}{1:D2}", result, max + 1);
        }

        /// <summary>
        /// Đếm tổng học viên
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return (from p in GlobalSettings.Database.HOCVIENs
                    select p).Count();
        }

        /// <summary>
        /// Đếm học viên tiềm năng
        /// </summary>
        /// <returns></returns>
        public int CountTiemNang()
        {
            return (from p in GlobalSettings.Database.HOCVIENs
                    where p.MaLoaiHV == "LHV00"
                    select p).Count();
        }

        /// <summary>
        /// Đếm học viên chính thức
        /// </summary>
        /// <returns></returns>
        public int CountChinhThuc()
        {
            return (from p in GlobalSettings.Database.HOCVIENs
                    where p.MaLoaiHV == "LHV01"
                    select p).Count();
        }
    }
}
