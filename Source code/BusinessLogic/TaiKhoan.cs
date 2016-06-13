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
                    where p.TenDangNhap==tenDangNhap
                    select p).Single();
        }

        public void Delete(string tenDangNhap)
        {
            var temp = (from p in Database.TAIKHOANs
                        where p.TenDangNhap == tenDangNhap
                        select p).Single();

            Database.TAIKHOANs.DeleteOnSubmit(temp);
            Database.SubmitChanges();
        }
    }
}
