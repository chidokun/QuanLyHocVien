using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BusinessLogic.GlobalSettings;
using DataAccess;

namespace BusinessLogic
{
    public class KhoaHoc
    {
        public object SelectAll()
        {
            return (from p in Database.KHOAHOCs
                    select p).ToList();
        }

        public KHOAHOC Select(string maKH)
        {
            return (from p in Database.KHOAHOCs
                    where p.MaKH == maKH
                    select p).Single();
        }
    }
}
