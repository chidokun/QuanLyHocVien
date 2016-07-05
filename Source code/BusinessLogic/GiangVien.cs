// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "GiangVien.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using static BusinessLogic.GlobalSettings;

namespace BusinessLogic
{
    public static class GiangVien
    {
        /// <summary>
        /// Chọn một giảng viên
        /// </summary>
        /// <param name="maGV"></param>
        /// <returns></returns>
        public static GIANGVIEN Select(string maGV)
        {
            return (from p in Database.GIANGVIENs
                    where p.MaGV == maGV
                    select p).Single();
        }

        /// <summary>
        /// Chọn tất cả giảng viên
        /// </summary>
        /// <returns></returns>
        public static object SelectAll()
        {
            return (from p in Database.GIANGVIENs
                    select p).ToList();
        }

        /// <summary>
        /// Chọn các giảng viên thỏa điều kiện
        /// </summary>
        /// <param name="maGV">Mã giảng viên</param>
        /// <param name="tenGV">Tên giảng viên</param>
        /// <param name="gioiTinh">Giới tính</param>
        /// <returns></returns>
        public static object SelectAll(string maGV, string tenGV, string gioiTinh)
        {
            return (from p in Database.GIANGVIENs
                    where (maGV == null ? true : p.MaGV.Contains(maGV)) &&
                          (tenGV == null ? true : p.TenGV.Contains(tenGV)) &&
                          (gioiTinh == null ? true : p.GioiTinhGV == gioiTinh)
                    select p).ToList();
        }

        /// <summary>
        /// Thêm giảng viên
        /// </summary>
        /// <param name="giangVien">Giảng viên</param>
        /// <param name="taiKhoan">Tài khoản</param>
        public static void Insert(GIANGVIEN giangVien, TAIKHOAN taiKhoan)
        {
            var f = TaiKhoan.SelectAll(taiKhoan.TenDangNhap, UserType.GiangVien);

            if (f.Count > 0)
                throw new Exception("Tên tài khoản đã tồn tại");
            else
                Database.TAIKHOANs.InsertOnSubmit(taiKhoan);
            Database.GIANGVIENs.InsertOnSubmit(giangVien);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Cập nhật thông tin giảng viên
        /// </summary>
        /// <param name="giangVien"></param>
        /// <param name="taiKhoan"></param>
        public static void Update(GIANGVIEN giangVien, TAIKHOAN taiKhoan = null)
        {
            var giangVienCu = Select(giangVien.MaGV);

            giangVienCu.TenGV = giangVien.TenGV;
            giangVienCu.GioiTinhGV = giangVien.GioiTinhGV;
            giangVienCu.SdtGV = giangVien.SdtGV;
            giangVienCu.EmailGV = giangVien.EmailGV;

            Database.SubmitChanges();
            if(taiKhoan!=null)
                TaiKhoan.Update(taiKhoan);    
        }

        /// <summary>
        /// Xóa một giảng viên
        /// </summary>
        /// <param name="maGV">Mã giảng viên cần xóa</param>
        public static void Delete(string maGV)
        {
            var temp = Select(maGV);
            string tenDangNhap = temp.TenDangNhap;

            //xóa giảng dạy
            GiangDay.Delete(maGV);

            //xóa giảng viên
            Database.GIANGVIENs.DeleteOnSubmit(temp);
            Database.SubmitChanges();

            //xóa tài khoản
            TaiKhoan.Delete(tenDangNhap);
        }

        /// <summary>
        /// Tự động sinh mã giảng viên
        /// </summary>
        /// <returns></returns>
        public static string AutoGenerateId()
        {
            string result = "GV";
            var temp = from p in GlobalSettings.Database.GIANGVIENs
                       where p.MaGV.StartsWith(result)
                       select p.MaGV;
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
