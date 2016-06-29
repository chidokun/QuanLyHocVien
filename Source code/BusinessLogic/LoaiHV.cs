// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "LoaiHV.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace BusinessLogic
{
    public static class LoaiHV
    {
        /// <summary>
        /// Chọn tất cả
        /// </summary>
        /// <returns></returns>
        public static List<LOAIHV> SelectAll()
        {
            var result = from p in GlobalSettings.Database.LOAIHVs
                         select p;

            return result.ToList();
        }
    }
}
