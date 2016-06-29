﻿// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmHocPhiHocVien.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;

namespace QuanLyHocVien.Pages
{
    public partial class frmHocPhiHocVien : Form
    {
        private KhoaHoc busKhoaHoc = new KhoaHoc();
        private BangDiem busBangDiem = new BangDiem();

        public frmHocPhiHocVien()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalPages.HocPhiHocVien = null;
        }

        private void frmHocPhiHocVien_Load(object sender, EventArgs e)
        {
            btnDatLai_Click(sender, e);

            cboKhoaHoc.DataSource = busKhoaHoc.SelectAll();
            cboKhoaHoc.DisplayMember = "TenKH";
            cboKhoaHoc.ValueMember = "MaKH";

            btnXemTatCa_Click(sender, e);

            lblTenLop.Text = string.Empty;
            lblMaLop.Text = string.Empty;
            lblTenKH.Text = string.Empty;
            lblNgayBD.Text = string.Empty;
            lblNgayKT.Text = string.Empty;
            lblSiSo.Text = string.Empty;
            lblDaDong.Text = string.Empty;
            lblConNo.Text = string.Empty;
            lblTongNoTatCa.Text = string.Empty;

            gridLop.AutoGenerateColumns = false;
        }

        private void rdKhoangThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            dateTuNgay.Enabled = dateDenNgay.Enabled = rdKhoangThoiGian.Checked;
        }

        private void rdKhoaHoc_CheckedChanged(object sender, EventArgs e)
        {
            cboKhoaHoc.Enabled = rdKhoaHoc.Checked;
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            rdKhoangThoiGian.Checked = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            gridLop.DataSource = busBangDiem.SelectDSLop(GlobalSettings.UserID, rdKhoangThoiGian.Checked ? (DateTime?)dateDenNgay.Value : null,
                rdKhoangThoiGian.Checked ? (DateTime?)dateDenNgay.Value : null, rdKhoaHoc.Checked ? cboKhoaHoc.SelectedValue.ToString() : null);

            gridLop_Click(sender, e);
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            gridLop.DataSource = busBangDiem.SelectDSLop(GlobalSettings.UserID);

            gridLop_Click(sender, e);
        }

        private void gridLop_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch { }
        }
    }
}
