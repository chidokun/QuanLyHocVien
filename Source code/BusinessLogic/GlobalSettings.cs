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
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogic
{
    public enum UserType { NhanVien, HocVien, GiangVien }
    public static class GlobalSettings
    {
        /// <summary>
        /// Đại diện cho cơ sở dữ liệu của chương trình
        /// </summary>
        public static QuanLyHocVienDataContext Database { get; set; }

        /// <summary>
        /// Đại diện cho chuỗi kết nối
        /// </summary>
        public static string ConnectionString { get; set; }

        /// <summary>
        /// Đại diện cho mã người dùng đăng nhập
        /// </summary>
        public static string UserID { get; set; }

        /// <summary>
        /// Đại diện cho tên người dùng đăng nhập
        /// </summary>
        public static string UserName { get; set; }

        /// <summary>
        /// Đại diện cho kiểu người dùng đăng nhập
        /// </summary>
        public static UserType UserType { get; set; }

        /// <summary>
        /// Đại diện cho tên server
        /// </summary>
        public static string ServerName { get; set; }

        /// <summary>
        /// Đại diện cho tên database
        /// </summary>
        public static string ServerCatalog { get; set; }

        /// <summary>
        /// Đại diện cho tên trung tâm
        /// </summary>
        public static string CenterName { get; set; }

        /// <summary>
        /// Đại diện cho địa chỉ trung tâm
        /// </summary>
        public static string CenterAddress { get; set; }

        /// <summary>
        /// Đại diện cho website trung tâm
        /// </summary>
        public static string CenterWebsite { get; set; }

        /// <summary>
        /// Đại diện cho email trung tâm
        /// </summary>
        public static string CenterEmail { get; set; }

        /// <summary>
        /// Đại diện cho số điện thoại trung tâm
        /// </summary>
        public static string CenterTelephone { get; set; }


        /// <summary>
        /// Kết nối đến cơ sở dữ liệu
        /// </summary>
        public static void ConnectToDatabase()
        {
            //nạp thông tin kết nối
            ConnectionString = Settings.Default.ConnectionString;
            ServerName = Settings.Default.Database_ServerName;
            ServerCatalog = Settings.Default.Database_ServerCatalog;

            Database = new QuanLyHocVienDataContext(ConnectionString);

            //kiểm tra kết nối
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select 1", connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Nạp thông tin trung tâm
        /// </summary>
        public static void LoadCenterInformation()
        {
            ChiTietTrungTam bus = new ChiTietTrungTam();
            CHITIETTRUNGTAM detail = bus.Select();

            CenterName = detail.TenTT;
            CenterAddress = detail.DiaChiTT;
            CenterWebsite = detail.Website;
            CenterEmail = detail.EmailTT;
            CenterTelephone = detail.SdtTT;
        }

        /// <summary>
        /// Lấy danh sách database
        /// </summary>
        /// <param name="connectionString">Chuỗi kết nối đến master</param>
        /// <returns></returns>
        public static List<string> GetDatabaseList(string connectionString)
        {
            List<string> list = new List<string>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("sp_databases", con))
                using (IDataReader dr = cmd.ExecuteReader())
                    while (dr.Read())
                        list.Add(dr[0].ToString());
            }

            return list;
        }

        /// <summary>
        /// Lưu lại kết nối cơ sở dữ liệu
        /// </summary>
        public static void SaveDatabaseConnection()
        {
            Settings.Default.ConnectionString = ConnectionString;
            Settings.Default.Database_ServerName = ServerName;
            Settings.Default.Database_ServerCatalog = ServerCatalog;

            Settings.Default.Save();
        }
    }
}
