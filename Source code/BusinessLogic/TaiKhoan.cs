using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using static BusinessLogic.GlobalSettings;

namespace BusinessLogic
{
    public class TaiKhoan
    {
        /// <summary>
        /// Chọn một tài khoản
        /// </summary>
        /// <param name="tenDangNhap">Tên đăng nhập</param>
        /// <returns></returns>
        public TAIKHOAN Select(string tenDangNhap)
        {
            return (from p in Database.TAIKHOANs
                    where p.TenDangNhap == tenDangNhap
                    select p).Single();
        }

        /// <summary>
        /// Xóa tài khoản
        /// </summary>
        /// <param name="tenDangNhap"></param>
        public void Delete(string tenDangNhap)
        {
            var temp = (from p in Database.TAIKHOANs
                        where p.TenDangNhap == tenDangNhap
                        select p).Single();

            Database.TAIKHOANs.DeleteOnSubmit(temp);
            Database.SubmitChanges();
        }

        /// <summary>
        /// Đổi mật khẩu
        /// </summary>
        /// <param name="tk"></param>
        public void Update(TAIKHOAN tk)
        {
            var temp = (from p in Database.TAIKHOANs
                        where p.TenDangNhap == tk.TenDangNhap
                        select p).Single();

            temp.MatKhau = tk.MatKhau;
            Database.SubmitChanges();
        }

        /// <summary>
        /// Trả về tên người dùng của tên đăng nhập
        /// </summary>
        /// <param name="tk"></param>
        public string FullUserName(TAIKHOAN tk)
        {
            var a = (from p in Database.NHANVIENs
                     where p.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (a != null)
                return a.TenNV;

            var b = (from p in Database.HOCVIENs
                     where p.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (b != null)
                return b.TenHV;

            var c = (from p in Database.GIANGVIENs
                     where p.TenDangNhap == tk.TenDangNhap
                     select p).SingleOrDefault();
            if (c != null)
                return c.TenGV;
            return null;
        }
    }
}
