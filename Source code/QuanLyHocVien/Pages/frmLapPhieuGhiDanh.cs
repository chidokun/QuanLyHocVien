// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmLapPhieuGhiDanh.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;
using System.Threading;
using QuanLyHocVien.Reports;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;

namespace QuanLyHocVien.Pages
{
    public partial class frmLapPhieuGhiDanh : Form
    {
        private Thread thHocVien;
        private string maPhieu;
        private string maHV;
        private string maKH;

        public frmLapPhieuGhiDanh()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load các phiếu ghi danh
        /// </summary>
        public void LoadPhieuGhiDanh()
        {
            //thPhieuGhiDanh = new Thread(() =>
            //{
            object source = PhieuGhiDanh.SelectAll();

            //gridPhieuGhiDanh.Invoke((MethodInvoker)delegate
            // {
            gridPhieuGhiDanh.DataSource = source;
            //});
            //});
            //thPhieuGhiDanh.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalPages.LapPhieuGhiDanh = null;
        }

        private void rdMaHV_CheckedChanged(object sender, EventArgs e)
        {
            txtMaHV.Enabled = rdMaHV.Checked;
        }

        private void rdTenHV_CheckedChanged(object sender, EventArgs e)
        {
            txtTenHV.Enabled = rdTenHV.Checked;
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            txtMaHV.Text = txtTenHV.Text = string.Empty;
            rdMaHV.Checked = true;
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            gridDSHV.AutoGenerateColumns = false;

            thHocVien = new Thread(() =>
            {
                //thPhieuGhiDanh.Join();

                object source = HocVien.SelectAll();

                gridDSHV.Invoke((MethodInvoker)delegate
                {
                    gridDSHV.DataSource = source;
                });
            });
            thHocVien.Start();
        }

        private void gridDSHV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCongHV.Text = string.Format("Tổng cộng: {0} kết quả", gridDSHV.Rows.Count);
        }

        private void gridDSHV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCongHV.Text = string.Format("Tổng cộng: {0} kết quả", gridDSHV.Rows.Count);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (rdMaHV.Checked)
            {
                gridDSHV.DataSource = HocVien.SelectAll(txtMaHV.Text, null, null, null, null, null);
            }
            else if (rdTenHV.Checked)
            {
                gridDSHV.DataSource = HocVien.SelectAll(null, txtTenHV.Text, null, null, null, null);
            }
        }

        private void frmLapPhieuGhiDanh_Load(object sender, EventArgs e)
        {
            //load khóa học
            cboKhoaHoc.DataSource = KhoaHoc.SelectAll();
            cboKhoaHoc.DisplayMember = "TenKH";

            //tạo mã phiếu
            txtMaPhieu.Text = PhieuGhiDanh.AutoGenerateId();

            //load danh sách phiếu
            LoadPhieuGhiDanh();

            //load danh sách học viên
            btnHienTatCa_Click(sender, e);
        }


        private void gridPhieuGhiDanh_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCongPhieu.Text = string.Format("Tổng cộng: {0} phiếu ghi danh", gridPhieuGhiDanh.Rows.Count);
        }

        private void gridPhieuGhiDanh_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCongPhieu.Text = string.Format("Tổng cộng: {0} phiếu ghi danh", gridPhieuGhiDanh.Rows.Count);
        }

        private void cboKhoaHoc_SelectedValueChanged(object sender, EventArgs e)
        {
            numHocPhi.Value = (decimal)((KHOAHOC)cboKhoaHoc.SelectedValue).HocPhi;
            numDaDong.Maximum = numHocPhi.Value;
            numConNo.Value = numHocPhi.Value - numDaDong.Value;
        }

        private void numDaDong_ValueChanged(object sender, EventArgs e)
        {
            numConNo.Value = numHocPhi.Value - numDaDong.Value;
        }

        private void btnDatLaiPhieu_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Text = PhieuGhiDanh.AutoGenerateId();
            numDaDong.Value = 0;
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                maPhieu = txtMaPhieu.Text;
                maHV = gridDSHV.SelectedRows[0].Cells["clmMaHV"].Value.ToString();
                maKH = ((KHOAHOC)cboKhoaHoc.SelectedValue).MaKH;
                PhieuGhiDanh.Insert(new PHIEUGHIDANH()
                {
                    MaPhieu = maPhieu,
                    NgayGhiDanh = dateNgayGhiDanh.Value,
                    DaDong = numDaDong.Value,
                    ConNo = numConNo.Value,
                    MaNV = GlobalSettings.UserID,

                    DANGKies = new DANGKY()
                    {
                        MaHV = maHV,
                        MaKH = maKH,
                        MaPhieu = maPhieu
                    }
                });
                MessageBox.Show("Thêm phiếu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadPhieuGhiDanh();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInBienLai_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn lưu phiếu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnLuuPhieu_Click(sender, e);

                frmReport frm = new frmReport();

                DANGKY d = DangKy.Select(maHV, maKH, maPhieu);

                List<ReportParameter> _params = new List<ReportParameter>()
                {
                    new ReportParameter("CenterName", GlobalSettings.CenterName),
                    new ReportParameter("CenterWebsite", GlobalSettings.CenterWebsite),
                    new ReportParameter("MaHV", maHV),
                    new ReportParameter("TenHV", d.HOCVIEN.TenHV),
                    new ReportParameter("TenKH", d.KHOAHOC.TenKH),
                    new ReportParameter("HocPhi",((decimal)d.KHOAHOC.HocPhi).ToString("C0")),
                    new ReportParameter("DaDong", ((decimal)d.PHIEUGHIDANH.DaDong).ToString("C0")),
                    new ReportParameter("ConNo", ((decimal)d.PHIEUGHIDANH.ConNo).ToString("C0")),
                };

                frm.ReportViewer.LocalReport.ReportEmbeddedResource = "QuanLyHocVien.Reports.rptBienLaiHocPhi.rdlc";

                frm.ReportViewer.LocalReport.SetParameters(_params);
                frm.ReportViewer.LocalReport.DisplayName = "Biên lai học phí";
                frm.Text = "Biên lai học phí";

                frm.ShowDialog();
            }
        }

        private void gridDSHV_Click(object sender, EventArgs e)
        {
            btnDatLaiPhieu_Click(sender, e);
        }
    }
}
