using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BusinessLogic.GlobalSettings;
using DataAccess;

namespace BusinessLogic
{
    public class PhieuGhiDanh
    {
        public object SelectAll()
        {
            return (from p in Database.PHIEUGHIDANHs
                    select new
                    {
                        MaPhieu = p.MaPhieu,
                        MaHV = p.DANGKies.MaHV,
                        NgayGhiDanh = p.NgayGhiDanh,
                        DaDong = p.DaDong,
                        ConNo = p.ConNo
                    }).ToList();
        }

        public void Insert(PHIEUGHIDANH p)
        {
            Database.PHIEUGHIDANHs.InsertOnSubmit(p);
         
            Database.SubmitChanges();
        }

        public string AutoGenerateId()
        {
            string result = "PG" + DateTime.Now.ToString("yyMMdd");
            var temp = from p in GlobalSettings.Database.PHIEUGHIDANHs
                       where p.MaPhieu.StartsWith(result)
                       select p.MaPhieu;
            int max = 0;

            foreach (var i in temp)
            {
                int j = int.Parse(i.Substring(8, 2));
                if (j > max) max = j;
            }

            return string.Format("{0}{1:D2}", result, max + 1);
        }
    }
}
