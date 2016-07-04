// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "DangKy.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BusinessLogic.GlobalSettings;
using DataAccess;

namespace BusinessLogic
{
    public static class DangKy
    {
        /// <summary>
        /// Thêm một đăng ký
        /// </summary>
        /// <param name="dk"></param>
        public static void Insert(DANGKY dk)
        {
            Database.DANGKies.InsertOnSubmit(dk);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Chọn một đăng ký
        /// </summary>
        /// <param name="maHV">Mã học viên</param>
        /// <param name="maKH">Mã khóa học</param>
        /// <param name="maPhieu">Mã phiếu</param>
        /// <returns></returns>
        public static DANGKY Select(string maHV, string maKH, string maPhieu)
        {
            return (from p in Database.DANGKies
                    where p.MaHV == maHV && p.MaKH == maKH && p.MaPhieu == maPhieu
                    select p).Single();
        }

        /// <summary>
        /// Tìm một đăng ký
        /// </summary>
        /// <param name="maHV">Mã học viên</param>
        /// <returns></returns>
        public static IQueryable<DANGKY> SelectAll(string maHV)
        {
            return (from p in Database.DANGKies
                    where p.MaHV == maHV
                    select p);
        }
    }
}
