// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmXemCacLopDay.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;

namespace QuanLyHocVien.Pages
{
    public partial class frmXemCacLopDay : Form
    {
        public frmXemCacLopDay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Nạp lớp lên giao diện
        /// </summary>
        /// <param name="lh"></param>
        public void LoadUI(LOPHOC lh = null)
        {
            if (lh != null)
            {
                lblTenLop.Text = lh.TenLop;
                lblMaLop.Text = lh.MaLop;
                lblKhoa.Text = lh.KHOAHOC.TenKH;
                lblNgayBatDau.Text = lh.NgayBD.Value.ToShortDateString();
                lblNgayKetThuc.Text = lh.NgayKT.Value.ToShortDateString();
                lblSiSo.Text = lh.SiSo.ToString();
            }
            else
            {
                lblTenLop.Text = string.Empty;
                lblMaLop.Text = string.Empty;
                lblKhoa.Text = string.Empty;
                lblNgayBatDau.Text = string.Empty;
                lblNgayKetThuc.Text = string.Empty;
                lblSiSo.Text = string.Empty;
            }
        }

        #region Events
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
            dateTuNgay.MaxDate = dateDenNgay.MaxDate = DateTime.Now;

            //load khóa học
            cboKhoaHoc.DataSource = KhoaHoc.SelectAll();
            cboKhoaHoc.DisplayMember = "TenKH";
            cboKhoaHoc.ValueMember = "MaKH";

            gridKetQuaTimKiem.AutoGenerateColumns = false;

            btnXemTatCa_Click(sender, e);
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            rdKhoangThoiGian.Checked = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            gridKetQuaTimKiem.DataSource = GiangDay.SelectAll(GlobalSettings.UserID, rdKhoangThoiGian.Checked ? (DateTime?)dateTuNgay.Value : null,
                rdKhoangThoiGian.Checked ? (DateTime?)dateDenNgay.Value : null, rdKhoaHoc.Checked ? cboKhoaHoc.SelectedValue.ToString() : null);

            gridKetQuaTimKiem_Click(sender, e);
        }

        private void gridKetQuaTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUI(LopHoc.Select(gridKetQuaTimKiem.SelectedRows[0].Cells["clmMaLop"].Value.ToString()));
            }
            catch
            {
                LoadUI();
            }
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            gridKetQuaTimKiem.DataSource = GiangDay.SelectAll(GlobalSettings.UserID, null, null, null);

            gridKetQuaTimKiem_Click(sender, e);
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            dateTuNgay.MaxDate = dateDenNgay.Value;
        }
        #endregion
    }
}
