// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmQuanLyLopHoc.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;
using QuanLyHocVien.Popups;

namespace QuanLyHocVien.Pages
{
    public partial class frmQuanLyLopHoc : Form
    {
        public frmQuanLyLopHoc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Kiểm tra nhập liệu tìm kiếm có hợp lệ
        /// </summary>
        public void ValidateSearch()
        {
            if (chkMaLop.Checked && txtMaLop.Text == string.Empty)
                throw new ArgumentException("Mã lớp không được trống");
            if (chkTenLop.Checked && txtTenLop.Text == string.Empty)
                throw new ArgumentException("Tên lớp không được trống");
        }

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalPages.QuanLyLopHoc = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmLopHocEdit frm = new frmLopHocEdit();
            frm.Text = "Thêm lớp mới";
            frm.ShowDialog();

            btnHienTatCa_Click(sender, e);
        }

        private void chkMaLop_CheckedChanged(object sender, EventArgs e)
        {
            txtMaLop.Enabled = chkMaLop.Checked;
        }

        private void chkTenLop_CheckedChanged(object sender, EventArgs e)
        {
            txtTenLop.Enabled = chkTenLop.Checked;
        }

        private void chkKhoa_CheckedChanged(object sender, EventArgs e)
        {
            cboKhoa.Enabled = chkKhoa.Checked;
        }

        private void chkKhoangTG_CheckedChanged(object sender, EventArgs e)
        {
            dateTuNgay.Enabled = dateDenNgay.Enabled = chkKhoangTG.Checked;
        }

        private void chkTinhTrang_CheckedChanged(object sender, EventArgs e)
        {
            rdMo.Enabled = rdDong.Enabled = chkTinhTrang.Checked;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSearch();

                gridLop.DataSource = LopHoc.SelectAll(chkMaLop.Checked ? txtMaLop.Text : null,
                    chkTenLop.Checked ? txtTenLop.Text : null,
                    chkKhoa.Checked ? cboKhoa.SelectedValue.ToString() : null,
                    chkKhoangTG.Checked ? (DateTime?)dateTuNgay.Value : null,
                    chkKhoangTG.Checked ? (DateTime?)dateDenNgay.Value : null,
                    chkTinhTrang.Checked ? (bool?)rdMo.Checked : null);
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

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            chkMaLop.Checked = true;
            txtMaLop.Text = string.Empty;
            chkTenLop.Checked = false;
            txtTenLop.Text = string.Empty;
            chkKhoa.Checked = false;
            chkKhoangTG.Checked = false;
            chkTinhTrang.Checked = false;
        }

        private void frmQuanLyLopHoc_Load(object sender, EventArgs e)
        {
            dateTuNgay.MaxDate = dateDenNgay.MaxDate = DateTime.Now;

            cboKhoa.DataSource = KhoaHoc.SelectAll();
            cboKhoa.DisplayMember = "TenKH";
            cboKhoa.ValueMember = "MaKH";

            btnDatLai_Click(sender, e);

            gridLop.AutoGenerateColumns = false;
            btnHienTatCa_Click(sender, e);
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            gridLop.DataSource = LopHoc.SelectAll();

            gridLop_Click(sender, e);
        }

        private void gridLop_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} lớp", gridLop.Rows.Count);
        }

        private void gridLop_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} lớp", gridLop.Rows.Count);
        }

        private void gridLop_Click(object sender, EventArgs e)
        {
            try
            {
                LOPHOC lop = LopHoc.Select(gridLop.SelectedRows[0].Cells["clmMaLop"].Value.ToString());

                lblTenLop.Text = lop.TenLop;
                lblMaLop.Text = lop.MaLop;
                lblKhoa.Text = lop.KHOAHOC.TenKH;
                lblSiSo.Text = lop.SiSo.ToString();
                lblNgayBatDau.Text = lop.NgayBD.ToString();
                lblNgayKetThuc.Text = lop.NgayKT.ToString();
            }
            catch { }
        }

        private void gridLop_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmLopHocEdit frm = new frmLopHocEdit(LopHoc.Select(gridLop.SelectedRows[0].Cells["clmMaLop"].Value.ToString()));
            frm.Text = "Cập nhật thông tin lớp";
            frm.ShowDialog();

            btnHienTatCa_Click(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LopHoc.Delete(gridLop.SelectedRows[0].Cells["clmMaLop"].Value.ToString());

                    MessageBox.Show("Xóa lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnHienTatCa_Click(sender, e);
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            dateTuNgay.MaxDate = dateDenNgay.Value;
        }
        #endregion
    }
}
