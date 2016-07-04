// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmTrangMoDau.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Diagnostics;
using System.Windows.Forms;

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
    }
}
