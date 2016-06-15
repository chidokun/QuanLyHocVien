// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmBangDiem.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;
using System.Collections.Generic;
using Microsoft.Reporting.WinForms;

namespace QuanLyHocVien
{
    public partial class frmBangDiem : Form
    {
        private BangDiem busBangDiem = new BangDiem();

        public frmBangDiem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Nạp bảng điểm lên giao diện
        /// </summary>
        /// <param name="maHV"></param>
        /// <param name="maLop"></param>
        public void LoadBangDiem(string maHV, string maLop)
        {
            var bangDiem = busBangDiem.SelectDetail(maHV, maLop);
            lblTenLop.Text = bangDiem.TenLop;
            lblTenKhoa.Text = bangDiem.TenKH;
            lblDiemNghe.Text = bangDiem.DiemNghe.ToString();
            lblDiemNoi.Text = bangDiem.DiemNoi.ToString();
            lblDiemDoc.Text = bangDiem.DiemDoc.ToString();
            lblDiemViet.Text = bangDiem.DiemViet.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBangDiem_Load(object sender, EventArgs e)
        {
            cboLop.DataSource = busBangDiem.SelectDSLop(GlobalSettings.CurrentUser);
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";

            lblTenLop.Text = lblTenKhoa.Text = string.Empty;

            lblDiemNghe.Text = lblDiemNoi.Text = lblDiemDoc.Text = lblDiemViet.Text = lblDiemTrungBinh.Text = 0.ToString();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadBangDiem(GlobalSettings.CurrentUser, cboLop.SelectedValue.ToString());
        }

        private void btnInBangDiem_Click(object sender, EventArgs e)
        {
            //frmReport frm = new frmReport()
            //{
            //    ReportResource = "QuanLyHocVien.Reports.rptBangDiem.rdlc",
            //    //DataSource.Add(),
            //    Parameters = new List<ReportParameter>()
            //    {
            //        new ReportParameter("CenterName",GlobalSettings.CenterName),
            //        new ReportParameter("CenterWebsite",GlobalSettings.CenterWebsite),
            //        new ReportParameter("MaHV","")
            //    }

            //};

            //frm.ShowDialog();
        }
    }

}
