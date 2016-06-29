// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmQuanLyHocPhi.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;

namespace QuanLyHocVien.Pages
{
    public partial class frmQuanLyHocPhi : Form
    {
        public frmQuanLyHocPhi()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalPages.QuanLyHocPhi = null;
        }
    }
}
