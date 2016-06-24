// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmQuanLyTaiKhoan.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;

namespace QuanLyHocVien.Pages
{
    public partial class frmQuanLyTaiKhoan : Form
    {
        private TaiKhoan busTaiKhoan = new TaiKhoan();

        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkTen_CheckedChanged(object sender, EventArgs e)
        {
            txtTen.Enabled = chkTen.Checked;
        }

        private void chkLoaiTK_CheckedChanged(object sender, EventArgs e)
        {
            cboLoaiTK.Enabled = chkLoaiTK.Checked;
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            chkTen.Checked = true;
            txtTen.Text = string.Empty;
        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            cboLoaiTK.Items.AddRange(new string[]
            {
                "Nhân viên",
                "Học viên",
                "Giảng viên"
            });
            cboLoaiTK.SelectedIndex = 0;

            btnDatLai_Click(sender, e);
            gridKetQua.AutoGenerateColumns = false;
            btnXemTatCa_Click(sender, e);
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            gridKetQua.DataSource = busTaiKhoan.SelectAll(null, null);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            gridKetQua.DataSource = busTaiKhoan.SelectAll(chkTen.Checked ? txtTen.Text : null, chkLoaiTK.Checked ? (int?)cboLoaiTK.SelectedIndex : null);
        }

        private void gridKetQua_Click(object sender, EventArgs e)
        {
            try
            {
                txtTenDangNhap.Text = gridKetQua.SelectedRows[0].Cells["clmTenDangNhap"].Value.ToString();
                txtMatKhau.Text = gridKetQua.SelectedRows[0].Cells["clmMatKhau"].Value.ToString();
            }
            catch { }
        }

        private void gridKetQua_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} kết quả", gridKetQua.Rows.Count);
        }

        private void gridKetQua_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} kết quả", gridKetQua.Rows.Count);
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = txtMatKhau.Text = string.Empty;
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                busTaiKhoan.Update(new TAIKHOAN()
                {
                    TenDangNhap = txtTenDangNhap.Text,
                    MatKhau = txtMatKhau.Text,
                });

                MessageBox.Show("Cập nhật tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnTimKiem_Click(sender, e);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
