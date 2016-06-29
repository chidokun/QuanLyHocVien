// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "ChiTietTrungTam.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System.Linq;
using static BusinessLogic.GlobalSettings;
using DataAccess;

namespace BusinessLogic
{
    public static class ChiTietTrungTam
    {
        /// <summary>
        /// Lấy chi tiết trung tâm
        /// </summary>
        /// <returns></returns>
        public static CHITIETTRUNGTAM Select()
        {
            return (from p in Database.CHITIETTRUNGTAMs
                    select p).Single();
        }

        /// <summary>
        /// Cập nhật chi tiết trung tâm
        /// </summary>
        /// <param name="ct"></param>
        public static void Update(CHITIETTRUNGTAM ct)
        {
            Database.CHITIETTRUNGTAMs.DeleteOnSubmit(Select());
            Database.SubmitChanges();
            Database.CHITIETTRUNGTAMs.InsertOnSubmit(ct);
            Database.SubmitChanges();
        }
    }
}
