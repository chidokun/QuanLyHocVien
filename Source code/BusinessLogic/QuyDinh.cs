// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "QuyDinh.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BusinessLogic.GlobalSettings;
using DataAccess;

namespace BusinessLogic
{
    public class QuyDinh
    {
        /// <summary>
        /// Chọn tất cả các quy định
        /// </summary>
        /// <returns></returns>
        public List<QUYDINH> SelectAll()
        {
            return (from p in Database.QUYDINHs
                    select p).ToList();
        }

        /// <summary>
        /// Chọn một quy định
        /// </summary>
        /// <param name="maQD">Mã quy định</param>
        /// <returns></returns>
        public QUYDINH Select(string maQD)
        {
            return (from p in Database.QUYDINHs
                    where p.MaQD == maQD
                    select p).Single();
        }

        /// <summary>
        /// Cập nhật một quy định
        /// </summary>
        /// <param name="qd">Quy định cần cập nhật</param>
        public void Update(QUYDINH qd)
        {
            var qdCu = Select(qd.MaQD);
            qdCu.GiaTri = qd.GiaTri;

            Database.SubmitChanges();
        }
    }
}
