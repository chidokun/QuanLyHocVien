// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "LoaiNV.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System.Collections.Generic;
using System.Linq;
using DataAccess;
using static BusinessLogic.GlobalSettings;

namespace BusinessLogic
{
    public static class LoaiNV
    {
        /// <summary>
        /// Chọn tất cả loại nhân viên
        /// </summary>
        /// <returns></returns>
        public static List<LOAINV> SelectAll()
        {
            return (from p in Database.LOAINVs
                    select p).ToList();
        }
    }
}
