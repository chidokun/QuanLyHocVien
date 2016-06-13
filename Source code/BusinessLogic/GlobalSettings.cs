using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using BusinessLogic.Properties;
namespace BusinessLogic
{
    public static class GlobalSettings
    {
        public static QuanLyHocVienDataContext Database { get; set; }

        public static string ConnectionString { get; set; }

        public static object CurrentUser { get; set; }

        public static string ServerName { get; set; }

        public static void LoadSettings()
        {
            Database = new QuanLyHocVienDataContext();
        }
    }
}
