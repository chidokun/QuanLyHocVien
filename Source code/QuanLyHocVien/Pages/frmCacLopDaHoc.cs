// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmCacLopDaHoc.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;

namespace QuanLyHocVien.Pages
{
    public partial class frmCacLopDaHoc : Form
    {
        public frmCacLopDaHoc()
        {
            InitializeComponent();
        }

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalPages.CacLopDaHoc = null;
        }

        private void frmCacLopDaHoc_Load(object sender, EventArgs e)
        {
            dateTuNgay.MaxDate = dateDenNgay.MaxDate = DateTime.Now;

            cboKhoaHoc.DataSource = KhoaHoc.SelectAll();
            cboKhoaHoc.DisplayMember = "TenKH";
            cboKhoaHoc.ValueMember = "MaKH";

            gridLop.AutoGenerateColumns = false;

            btnDatLai_Click(sender, e);
            btnXemTatCa_Click(sender, e);
        }

        private void rdKhoangThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            dateTuNgay.Enabled = dateDenNgay.Enabled = rdKhoangThoiGian.Checked;
        }

        private void rdKhoaHoc_CheckedChanged(object sender, EventArgs e)
        {
            cboKhoaHoc.Enabled = rdKhoaHoc.Checked;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            gridLop.DataSource = BangDiem.SelectDSLop(GlobalSettings.UserID, rdKhoangThoiGian.Checked ? (DateTime?)dateDenNgay.Value : null,
                rdKhoangThoiGian.Checked ? (DateTime?)dateDenNgay.Value : null, rdKhoaHoc.Checked ? cboKhoaHoc.SelectedValue.ToString() : null);

            gridLop_Click(sender, e);
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            rdKhoangThoiGian.Checked = true;
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            gridLop.DataSource = BangDiem.SelectDSLop(GlobalSettings.UserID, null, null, null);

            gridLop_Click(sender, e);
        }

        private void gridLop_Click(object sender, EventArgs e)
        {
            try
            {
                var temp = BangDiem.SelectDetail(GlobalSettings.UserID, gridLop.SelectedRows[0].Cells["clmMaLop"].Value.ToString());
                lblTenLop.Text = temp.TenLop;
                lblMaLop.Text = temp.MaLop;
                lblTenKH.Text = temp.TenKH;
                lblNgayBD.Text = temp.NgayBD.Value.ToShortDateString();
                lblNgayKT.Text = temp.NgayKT.Value.ToShortDateString();
                lblSiSo.Text = temp.SiSo.ToString();
                lblTinhTrang.Text = (bool)temp.DangMo ? "Đang mở" : "Đã đóng";
                lblDiemTB.Text = temp.DiemTrungBinh.ToString();
            }
            catch
            {
                lblTenLop.Text = string.Empty;
                lblMaLop.Text = string.Empty;
                lblTenKH.Text = string.Empty;
                lblNgayBD.Text = string.Empty;
                lblNgayKT.Text = string.Empty;
                lblSiSo.Text = string.Empty;
                lblTinhTrang.Text = string.Empty;
                lblDiemTB.Text = string.Empty;
            }
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            dateTuNgay.MaxDate = dateDenNgay.Value;
        }
        #endregion
    }
}
