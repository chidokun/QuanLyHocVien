// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmLopHocEdit.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;

namespace QuanLyHocVien
{
    public partial class frmLopHocEdit : Form
    {
        private KhoaHoc busKhoaHoc = new KhoaHoc();
        private LopHoc busLopHoc = new LopHoc();
        private LOPHOC lh;
        private bool isInsert = false;

        public frmLopHocEdit(LOPHOC lh = null)
        {
            InitializeComponent();
            this.lh = lh;
            isInsert = lh == null;
        }

        /// <summary>
        /// Nạp lớp lên giao diện
        /// </summary>
        /// <param name="lh"></param>
        public void LoadUI(LOPHOC lh)
        {
            if (lh == null)
            {
                txtMaLop.Text = busLopHoc.AutoGenerateId(dateNgayBD.Value);
            }
            else
            {
                txtMaLop.Text = lh.MaLop;
                txtTenLop.Text = lh.TenLop;
                dateNgayBD.Value = (DateTime)lh.NgayBD;
                dateNgayBD.Enabled = cboKhoa.Enabled = isInsert;
                dateNgayKT.Value = (DateTime)lh.NgayKT;
                cboKhoa.SelectedValue = lh.MaKH;
                rdMo.Checked = (bool)lh.DangMo;
                rdDong.Checked = !(bool)lh.DangMo;
            }
        }

        /// <summary>
        /// Nạp giao diện thành đối tượng
        /// </summary>
        /// <returns></returns>
        private LOPHOC LoadLopHoc()
        {
            return new LOPHOC()
            {
                MaLop = txtMaLop.Text,
                TenLop = txtTenLop.Text,
                NgayBD = dateNgayBD.Value,
                NgayKT = dateNgayKT.Value,
                SiSo = lh == null ? 0 : lh.SiSo,
                MaKH=cboKhoa.SelectedValue.ToString(),
                DangMo = rdMo.Checked
            };
        }

        private void dateNgayBD_ValueChanged(object sender, EventArgs e)
        {
            if (isInsert)
                txtMaLop.Text = busLopHoc.AutoGenerateId(dateNgayBD.Value);
        }

        private void frmLopHocEdit_Load(object sender, EventArgs e)
        {
            cboKhoa.DataSource = busKhoaHoc.SelectAll();
            cboKhoa.DisplayMember = "TenKH";
            cboKhoa.ValueMember = "MaKH";

            LoadUI(lh);
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                if (isInsert)
                {
                    busLopHoc.Insert(LoadLopHoc());

                    MessageBox.Show("Thêm lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    busLopHoc.Update(LoadLopHoc());

                    MessageBox.Show("Sửa lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
