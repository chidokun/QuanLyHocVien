// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmQuanLyNhanVien.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using QuanLyHocVien.Popups;

namespace QuanLyHocVien.Pages
{
    public partial class frmQuanLyNhanVien : Form
    {
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Kiểm tra nhập liệu tìm kiếm có hợp lệ
        /// </summary>
        public void ValidateSearch()
        {
            if (chkMaNV.Checked && txtMaNV.Text == string.Empty)
                throw new ArgumentException("Mã nhân viên không được trống");
            if (chkTenNV.Checked && txtTenNV.Text == string.Empty)
                throw new ArgumentException("Họ và tên nhân viên không được trống");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalPages.QuanLyNhanVien = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmNhanVienEdit frm = new frmNhanVienEdit(null);
            frm.Text = "Thêm nhân viên mới";
            frm.ShowDialog();

            btnHienTatCa_Click(sender, e);
        }

        private void chkMaNV_CheckedChanged(object sender, EventArgs e)
        {
            txtMaNV.Enabled = chkMaNV.Checked;
        }

        private void chkTenNV_CheckedChanged(object sender, EventArgs e)
        {
            txtTenNV.Enabled = chkTenNV.Checked;
        }

        private void chkLoaiNV_CheckedChanged(object sender, EventArgs e)
        {
            cboLoaiNV.Enabled = chkLoaiNV.Checked;
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            chkMaNV.Checked = true;
            txtMaNV.Text = txtTenNV.Text = string.Empty;
            chkTenNV.Checked = chkLoaiNV.Checked = false;
        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            //load loại nhân viên
            cboLoaiNV.DataSource = LoaiNV.SelectAll();
            cboLoaiNV.DisplayMember = "TenLoaiNV";
            cboLoaiNV.ValueMember = "MaLoaiNV";

            btnDatLai_Click(sender, e);
            btnHienTatCa_Click(sender, e);
        }

        private void gridNV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} nhân viên", gridNV.Rows.Count);
        }

        private void gridNV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} nhân viên", gridNV.Rows.Count);
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            gridNV.DataSource = NhanVien.SelectAll();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSearch();

                gridNV.DataSource = NhanVien.SelectAll(chkMaNV.Checked ? txtMaNV.Text : null,
                chkTenNV.Checked ? txtTenNV.Text : null, chkLoaiNV.Checked ? cboLoaiNV.SelectedValue.ToString() : null);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmNhanVienEdit frm = new frmNhanVienEdit(NhanVien.Select(gridNV.SelectedRows[0].Cells["clmMaNV"].Value.ToString()));
            frm.Text = "Cập nhật thông tin nhân viên";
            frm.ShowDialog();

            btnHienTatCa_Click(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NhanVien.Delete(gridNV.SelectedRows[0].Cells["clmMaNV"].Value.ToString());

                    MessageBox.Show("Xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnHienTatCa_Click(sender, e);
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridNV_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }
    }
}
