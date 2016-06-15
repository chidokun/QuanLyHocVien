// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmGiangDay.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using static BusinessLogic.GlobalSettings;

namespace BusinessLogic
{
    public class GiangDay
    {
        /// <summary>
        /// Chọn danh sách lớp của giảng viên
        /// </summary>
        /// <param name="maGV"></param>
        /// <returns></returns>
        public object Select(string maGV)
        {
            return (from p in Database.GIANGDAYs
                    where p.MaGV == maGV
                    select new
                    {
                        MaLop = p.MaLop,
                        TenLop = p.LOPHOC.TenLop,
                        NgayBatDau = p.LOPHOC.NgayBD,
                        NgayKetThuc = p.LOPHOC.NgayKT,
                        DangMo = p.LOPHOC.DangMo,
                        SiSo = p.LOPHOC.SiSo
                    }).ToList();
        }


        /// <summary>
        /// Xóa một quá trình giảng dạy của giảng viên
        /// </summary>
        /// <param name="maGV"></param>
        public void Delete(string maGV)
        {
            var temp = (from p in Database.GIANGDAYs
                        where p.MaGV == maGV
                        select p);

            Database.GIANGDAYs.DeleteAllOnSubmit(temp);
            Database.SubmitChanges();
        }
    }
}
