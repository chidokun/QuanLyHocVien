// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "NhanVien.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using static BusinessLogic.GlobalSettings;

namespace BusinessLogic
{
    public static class NhanVien
    {
        /// <summary>
        /// Chọn một nhân viên
        /// </summary>
        /// <param name="maNV"></param>
        /// <returns></returns>
        public static NHANVIEN Select(string maNV)
        {
            return (from p in Database.NHANVIENs
                    where p.MaNV == maNV
                    select p).Single();
        }

        /// <summary>
        /// Lấy danh sách tất cả nhân viên
        /// </summary>
        /// <returns></returns>
        public static object SelectAll()
        {
            return (from p in Database.NHANVIENs
                    select new
                    {
                        MaNV = p.MaNV,
                        TenNV = p.TenNV,
                        SdtNV = p.SdtNV,
                        EmailNV = p.EmailNV,
                        TenLoaiNV = p.LOAINV.TenLoaiNV
                    }).ToList();
        }

        /// <summary>
        /// Lấy danh sách nhân viên thỏa điều kiện
        /// </summary>
        /// <param name="maNV">Mã nhân viên</param>
        /// <param name="tenNV">Tên nhân viên</param>
        /// <param name="maLoaiHV">Mã loại nhân viên</param>
        /// <returns></returns>
        public static object SelectAll(string maNV, string tenNV, string maLoaiHV)
        {
            return (from p in GlobalSettings.Database.NHANVIENs
                    where (maNV == null ? true : p.MaNV.Contains(maNV)) &&
                          (tenNV == null ? true : p.TenNV.Contains(tenNV)) &&
                          (maLoaiHV == null ? true : p.MaLoaiNV == maLoaiHV)
                    select new
                    {
                        MaNV = p.MaNV,
                        TenNV = p.TenNV,
                        SdtNV = p.SdtNV,
                        EmailNV = p.EmailNV,
                        TenLoaiNV = p.LOAINV.TenLoaiNV
                    }).ToList();
        }

        /// <summary>
        /// Thêm nhân viên
        /// </summary>
        /// <param name="nhanVien">Nhân viên</param>
        /// <param name="taiKhoan">Tài khoản</param>
        public static void Insert(NHANVIEN nhanVien, TAIKHOAN taiKhoan)
        {
            var f = TaiKhoan.SelectAll(taiKhoan.TenDangNhap, UserType.NhanVien);

            if (f.Count > 0)
                throw new Exception("Tên tài khoản đã tồn tại");
            else
                Database.TAIKHOANs.InsertOnSubmit(taiKhoan);
            Database.NHANVIENs.InsertOnSubmit(nhanVien);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        /// <param name="nhanVien"></param>
        /// <param name="taiKhoan"></param>
        public static void Update(NHANVIEN nhanVien, TAIKHOAN taiKhoan = null)
        {
            var nhanVienCu = Select(nhanVien.MaNV);

            nhanVienCu.TenNV = nhanVien.TenNV;
            nhanVienCu.SdtNV = nhanVien.SdtNV;
            nhanVienCu.EmailNV = nhanVien.EmailNV;
            nhanVienCu.MaLoaiNV = nhanVien.MaLoaiNV;

            Database.SubmitChanges();
            if(taiKhoan!=null)
                TaiKhoan.Update(taiKhoan);         
        }

        /// <summary>
        /// Xóa một nhân viên
        /// </summary>
        /// <param name="maNV">Mã nhân viên cần xóa</param>
        public static void Delete(string maNV)
        {
            var temp = Select(maNV);
            string tenDangNhap = temp.TenDangNhap;

            Database.NHANVIENs.DeleteOnSubmit(temp);
            Database.SubmitChanges();

            TaiKhoan.Delete(tenDangNhap);
        }

        /// <summary>
        /// Tự động sinh mã nhân viên
        /// </summary>
        /// <returns></returns>
        public static string AutoGenerateId()
        {
            string result = "NV";
            var temp = from p in GlobalSettings.Database.NHANVIENs
                       where p.MaNV.StartsWith(result)
                       select p.MaNV;
            int max = -1;

            foreach (var i in temp)
            {
                int j = int.Parse(i.Substring(2, 4));
                if (j > max) max = j;
            }

            return string.Format("{0}{1:D4}", result, max + 1);
        }
    }
}
