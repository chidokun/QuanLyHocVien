// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "GlobalSettings.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

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

        public static string UserID { get; set; } = "GV0001";

        public static string CurrentUser { get; set; } = "admin"; //tạm

        public static string ServerName { get; set; }

        public static string CenterName { get; set; }
        public static string CenterAddress { get; set; }
        public static string CenterWebsite { get; set; }
        public static string CenterEmail { get; set; }
        public static string CenterTelephone { get; set; }

        public static void LoadDatabase()
        {
            Database = new QuanLyHocVienDataContext(/*ConnectionString*/);
        }

        public static void LoadCenterInformation(CHITIETTRUNGTAM detail = null)
        {
            ChiTietTrungTam bus = new ChiTietTrungTam();
            if (detail == null)
                detail = bus.Select();
            
            CenterName = detail.TenTT;
            CenterAddress = detail.DiaChiTT;
            CenterWebsite = detail.Website;
            CenterEmail = detail.EmailTT;
            CenterTelephone = detail.SdtTT;
        }
    }
}
