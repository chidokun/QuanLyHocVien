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
    }
}
