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
    public partial class frmLapPhieuGhiDanh : Form
    {
        private HocVien busHocVien = new HocVien();
        private KhoaHoc busKhoaHoc = new KhoaHoc();
        private PhieuGhiDanh busPhieuGhiDanh = new PhieuGhiDanh();

        public frmLapPhieuGhiDanh()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            gridDSHV.DataSource = busHocVien.SelectAll();
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
                gridDSHV.DataSource = busHocVien.SelectAll(txtMaHV.Text,null,null,null,null,null);
            }
            else if (rdTenHV.Checked)
            {
                gridDSHV.DataSource = busHocVien.SelectAll(null,txtTenHV.Text,null,null,null,null);
            }
        }

        private void frmLapPhieuGhiDanh_Load(object sender, EventArgs e)
        {
            //load khóa học
            cboKhoaHoc.DataSource = busKhoaHoc.SelectAll();
            cboKhoaHoc.DisplayMember = "TenKH";

            //tạo mã phiếu
            txtMaPhieu.Text = busPhieuGhiDanh.AutoGenerateId();

            //load danh sách phiếu
            gridPhieuGhiDanh.DataSource = busPhieuGhiDanh.SelectAll();

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
            txtMaPhieu.Text = busPhieuGhiDanh.AutoGenerateId();
            numDaDong.Value = 0;
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                busPhieuGhiDanh.Insert(new PHIEUGHIDANH()
                {
                    MaPhieu = txtMaPhieu.Text,
                    NgayGhiDanh = dateNgayGhiDanh.Value,
                    DaDong = numDaDong.Value,
                    ConNo = numConNo.Value,
                    MaNV = "NV0004",
                    //MaNV = GlobalSettings.CurrentUser.MaNV

                    DANGKies = new DANGKY()
                    {
                        MaHV = gridDSHV.SelectedRows[0].Cells["clmMaHV"].Value.ToString(),
                        MaKH = ((KHOAHOC)cboKhoaHoc.SelectedValue).MaKH,
                        MaPhieu = txtMaPhieu.Text
                    }
                });
                MessageBox.Show("Thêm phiếu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                gridPhieuGhiDanh.DataSource = busPhieuGhiDanh.SelectAll();
                btnDatLaiPhieu_Click(sender, e);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
