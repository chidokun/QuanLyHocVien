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
using QuanLyHocVien.Reports;

namespace QuanLyHocVien.Pages
{
    public partial class frmBangDiem : Form
    {
        private bool isLoaded = false;

        public frmBangDiem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Nạp bảng điểm lên giao diện
        /// </summary>
        /// <param name="maHV">Mã học viên</param>
        /// <param name="maLop">Mã lớp</param>
        public void LoadBangDiem(string maHV, string maLop)
        {
            var bangDiem = BangDiem.SelectDetail(maHV, maLop);
            lblTenLop.Text = bangDiem.TenLop;
            lblTenKhoa.Text = bangDiem.TenKH;
            lblDiemNghe.Text = bangDiem.DiemNghe.ToString();
            lblDiemNoi.Text = bangDiem.DiemNoi.ToString();
            lblDiemDoc.Text = bangDiem.DiemDoc.ToString();
            lblDiemViet.Text = bangDiem.DiemViet.ToString();
            lblDiemTrungBinh.Text = bangDiem.DiemTrungBinh.ToString("N2");
        }

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalPages.BangDiem = null;
        }

        private void frmBangDiem_Load(object sender, EventArgs e)
        {
            lblTitle.Text = string.Format("Bảng điểm của {0}", TaiKhoan.FullUserName(new TAIKHOAN() { TenDangNhap = GlobalSettings.UserName }));
            cboLop.DataSource = BangDiem.SelectDSLop(GlobalSettings.UserID);
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";

            lblTenLop.Text = lblTenKhoa.Text = string.Empty;

            lblDiemNghe.Text = lblDiemNoi.Text = lblDiemDoc.Text = lblDiemViet.Text = lblDiemTrungBinh.Text = 0.ToString();

            isLoaded = true;
            cboLop_SelectedValueChanged(sender, e);
        }

        private void btnInBangDiem_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport();

            List<ReportParameter> _params = new List<ReportParameter>()
            {
                new ReportParameter("CenterName", GlobalSettings.CenterName),
                new ReportParameter("CenterWebsite", GlobalSettings.CenterWebsite),
                new ReportParameter("MaHV", GlobalSettings.UserID),
                new ReportParameter("TenHV", TaiKhoan.FullUserName(new TAIKHOAN() {TenDangNhap = GlobalSettings.UserName })),
                new ReportParameter("MaLop", cboLop.SelectedValue.ToString()),
                new ReportParameter("TenLop",lblTenLop.Text),
                new ReportParameter("TenKH", lblTenKhoa.Text),
                new ReportParameter("DiemNghe", lblDiemNghe.Text),
                new ReportParameter("DiemNoi",lblDiemNoi.Text),
                new ReportParameter("DiemDoc",lblDiemDoc.Text),
                new ReportParameter("DiemViet",lblDiemViet.Text),
                new ReportParameter("DiemTB",lblDiemTrungBinh.Text)
            };

            frm.ReportViewer.LocalReport.ReportEmbeddedResource = "QuanLyHocVien.Reports.rptInBangDiem.rdlc";

            frm.ReportViewer.LocalReport.SetParameters(_params);
            frm.ReportViewer.LocalReport.DisplayName = "Bảng điểm học viên";
            frm.Text = "Bảng điểm học viên";

            frm.ShowDialog();
        }

        private void cboLop_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isLoaded)
                LoadBangDiem(GlobalSettings.UserName, cboLop.SelectedValue.ToString());
        }

        #endregion
    }
}
