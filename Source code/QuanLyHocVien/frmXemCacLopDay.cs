// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmXemCacLopDay.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;

namespace QuanLyHocVien
{
    public partial class frmXemCacLopDay : Form
    {
        private KhoaHoc busKhoaHoc = new KhoaHoc();

        public frmXemCacLopDay()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdKhoangThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            dateTuNgay.Enabled = dateDenNgay.Enabled = rdKhoangThoiGian.Checked;
        }

        private void rdKhoaHoc_CheckedChanged(object sender, EventArgs e)
        {
            cboKhoaHoc.Enabled = rdKhoaHoc.Checked;
        }

        private void frmXemCacLopDay_Load(object sender, EventArgs e)
        {
            //load khóa học
            cboKhoaHoc.DataSource = busKhoaHoc.SelectAll();
            cboKhoaHoc.DisplayMember = "TenKH";
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            rdKhoangThoiGian.Checked = true;
        }
    }
}
