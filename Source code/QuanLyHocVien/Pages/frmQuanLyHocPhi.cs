// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmQuanLyHocPhi.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using QuanLyHocVien.Reports;
using DataAccess;
using System.Collections.Generic;
using Microsoft.Reporting.WinForms;

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

        private void frmQuanLyHocPhi_Load(object sender, EventArgs e)
        {
            gridKetQua.AutoGenerateColumns = false;

            btnHienTatCa_Click(sender, e);
            gridKetQua_Click(sender, e);
        }

        private void chkMaHV_CheckedChanged(object sender, EventArgs e)
        {
            txtMaHV.Enabled = chkMaHV.Checked;
        }

        private void chkTenHV_CheckedChanged(object sender, EventArgs e)
        {
            txtTenHV.Enabled = chkTenHV.Checked;
        }

        private void chkGioiTinh_CheckedChanged(object sender, EventArgs e)
        {
            cboGioiTinh.Enabled = chkGioiTinh.Checked;
        }

        private void chkSoTienNo_CheckedChanged(object sender, EventArgs e)
        {
            numTu.Enabled = numDen.Enabled = chkSoTienNo.Checked;
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            chkMaHV.Checked = true;

            txtMaHV.Text = string.Empty;
            txtTenHV.Text = string.Empty;
            numTu.Value = numDen.Value = 0;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            gridKetQua.DataSource = BangDiem.DanhSachNoHocPhi(chkMaHV.Checked ? txtMaHV.Text : null, 
                chkTenHV.Checked ? txtTenHV.Text : null,
                chkGioiTinh.Checked ? cboGioiTinh.Text : null, 
                chkSoTienNo.Checked ? (decimal?)numTu.Value : null, 
                chkSoTienNo.Checked ? (decimal?)numDen.Value : null);
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            gridKetQua.DataSource = BangDiem.DanhSachNoHocPhi();
        }

        private void gridKetQua_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow r = gridKetQua.SelectedRows[0];
                var f = BangDiem.Select(r.Cells["clmMaHV"].Value.ToString(), r.Cells["clmMaLop"].Value.ToString());

                lblMaHV.Text = f.MaHV;
                lblTenHV.Text = f.HOCVIEN.TenHV;
                lblMaLop.Text = f.MaLop;
                lblTenLop.Text = f.LOPHOC.TenLop;
                lblTenKH.Text = f.LOPHOC.KHOAHOC.TenKH;
                lblHocPhi.Text = ((decimal)f.LOPHOC.KHOAHOC.HocPhi).ToString("C0");
                lblDaDong.Text = ((decimal)f.PHIEUGHIDANH.DaDong).ToString("C0");
                lblConNo.Text = ((decimal)f.PHIEUGHIDANH.ConNo).ToString("C0");
                numNop.Value = 0;

            }
            catch
            {
                lblMaHV.Text = string.Empty;
                lblTenHV.Text = string.Empty;
                lblMaLop.Text = string.Empty;
                lblTenLop.Text = string.Empty;
                lblTenKH.Text = string.Empty;
                lblHocPhi.Text = string.Empty;
                lblDaDong.Text = string.Empty;
                lblConNo.Text = string.Empty;
                numNop.Value = 0;
            }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {

        }

        private void btnInBienLai_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport();

            List<ReportParameter> _params = new List<ReportParameter>()
                {
                    new ReportParameter("CenterName", GlobalSettings.CenterName),
                    new ReportParameter("CenterWebsite", GlobalSettings.CenterWebsite),
                    new ReportParameter("MaHV", lblMaHV.Text),
                    new ReportParameter("TenHV", lblTenHV.Text),
                    new ReportParameter("TenKH", lblTenKH.Text),
                    new ReportParameter("HocPhi",lblHocPhi.Text),
                    new ReportParameter("DaDong", lblDaDong.Text),
                    new ReportParameter("ConNo", lblConNo.Text),
                };

            frm.ReportViewer.LocalReport.ReportEmbeddedResource = "QuanLyHocVien.Reports.rptBienLaiHocPhi.rdlc";

            frm.ReportViewer.LocalReport.SetParameters(_params);
            frm.ReportViewer.LocalReport.DisplayName = "Biên lai học phí";
            frm.Text = "Biên lai học phí";

            frm.ShowDialog();
        }
    }
}
