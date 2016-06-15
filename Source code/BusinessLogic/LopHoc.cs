// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmLopHoc.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using static BusinessLogic.GlobalSettings;

namespace BusinessLogic
{
    public class LopHoc
    {

       public object SelectAll()
        {
            return (from p in Database.LOPHOCs
                    select new
                    {
                        MaLop = p.MaLop,
                        TenLop = p.TenLop
                    }).ToList();
        }

        public object Select(string maLop)
        {
            return (from p in Database.LOPHOCs
                    where p.MaLop.Contains(maLop)
                    select new
                    {
                        MaLop = p.MaLop,
                        TenLop = p.TenLop
                    }).ToList();
        }

        
    }
}
