// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmTrangMoDau.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Diagnostics;
using System.Windows.Forms;
using BusinessLogic;

namespace QuanLyHocVien.Pages
{
    public partial class frmTrangMoDau : Form
    {
        public frmTrangMoDau()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTroGiup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/chidokun/QuanLyHocVien/wiki");
        }

        private void frmTrangMoDau_Load(object sender, EventArgs e)
        {
            lblCenter.Text = string.Format("TRUNG TÂM ANH NGỮ {0}", GlobalSettings.CenterName).ToUpper();
            lblAddress.Text = string.Format("Địa chỉ: {0}", GlobalSettings.CenterAddress);
            lblLienHe.Text = string.Format("Liên hệ: {0} - {1}", GlobalSettings.CenterWebsite, GlobalSettings.CenterEmail);
            lblWelcome.Text = string.Format("Xin chào, {0}", TaiKhoan.FullUserName(new DataAccess.TAIKHOAN() { TenDangNhap = GlobalSettings.UserName }));
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/chidokun/QuanLyHocVien/");
        }
    }
}
