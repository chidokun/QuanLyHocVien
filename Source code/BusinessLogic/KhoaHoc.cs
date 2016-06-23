// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "KhoaHoc.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)


using System.Linq;
using static BusinessLogic.GlobalSettings;
using DataAccess;

namespace BusinessLogic
{
    public class KhoaHoc
    {
        /// <summary>
        /// Chọn tất cả khóa học
        /// </summary>
        /// <returns></returns>
        public object SelectAll()
        {
            return (from p in Database.KHOAHOCs
                    select p).ToList();
        }

        /// <summary>
        /// Chọn một khóa học
        /// </summary>
        /// <param name="maKH">Mã khóa học</param>
        /// <returns></returns>
        public KHOAHOC Select(string maKH)
        {
            return (from p in Database.KHOAHOCs
                    where p.MaKH == maKH
                    select p).Single();
        }

        /// <summary>
        /// Thêm một khóa học
        /// </summary>
        /// <param name="kh">Khóa học cần thêm</param>
        public void Insert(KHOAHOC kh)
        {
            Database.KHOAHOCs.InsertOnSubmit(kh);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Cập nhật thông tin khóa học
        /// </summary>
        /// <param name="kh">Khóa học cần sửa</param>
        public void Update(KHOAHOC kh)
        {
            var khoaHocCu = Select(kh.MaKH);

            khoaHocCu.TenKH = kh.TenKH;
            khoaHocCu.HocPhi = kh.HocPhi;
            khoaHocCu.HeSoNghe = kh.HeSoNghe;
            khoaHocCu.HeSoNoi = kh.HeSoNoi;
            khoaHocCu.HeSoDoc = kh.HeSoDoc;
            khoaHocCu.HeSoViet = kh.HeSoViet;

            Database.SubmitChanges();
        }

        /// <summary>
        /// Xóa một khóa học
        /// </summary>
        /// <param name="maKH">Mã khóa học</param>
        public void Delete(string maKH)
        {
            var kh = (from p in Database.KHOAHOCs
                      where p.MaKH == maKH
                      select p).Single();

            //xóa bảng đăng ký
            var dk = from p in Database.DANGKies
                     where p.MaKH == maKH
                     select p;
            Database.DANGKies.DeleteAllOnSubmit(dk);

            //xóa bảng lớp học
            LopHoc lh = new LopHoc();
            var l = from p in Database.LOPHOCs
                    where p.MaKH == maKH
                    select p;
            foreach (var i in l)
            {
                lh.Delete(i.MaLop);
            }

            //xóa khóa học
            Database.KHOAHOCs.DeleteOnSubmit(kh);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Tự động sinh mã khóa học
        /// </summary>
        /// <returns></returns>
        public string AutoGenerateId()
        {
            string result = "KH";
            var temp = from p in GlobalSettings.Database.KHOAHOCs
                       select p.MaKH;
            int max = -1;

            foreach (var i in temp)
            {
                int j = int.Parse(i.Substring(2, 2));
                if (j > max) max = j;
            }

            return string.Format("{0}{1:D2}", result, max + 1);
        }
    }
}
