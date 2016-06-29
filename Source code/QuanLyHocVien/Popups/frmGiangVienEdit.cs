// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmGiangVienEdit.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;

namespace QuanLyHocVien.Popups
{
    public partial class frmGiangVienEdit : Form
    {
        private GiangVien busGiangVien = new GiangVien();
        private GIANGVIEN gv;
        private bool isInsert;

        public frmGiangVienEdit(GIANGVIEN gv)
        {
            InitializeComponent();
            this.gv = gv;
            isInsert = gv == null;
        }

        /// <summary>
        /// Nạp giảng viên lên giao diện
        /// </summary>
        /// <param name="gv"></param>
        public void LoadUI(GIANGVIEN gv)
        {
            if (gv == null)
            {
                txtMaGV.Text = busGiangVien.AutoGenerateId();
                cboGioiTinh.SelectedIndex = 0;
            }
            else
            {
                txtMaGV.Text = gv.MaGV;
                txtTenGV.Text = gv.TenGV;
                cboGioiTinh.Text = gv.GioiTinhGV;
                txtSDT.Text = gv.SdtGV;
                txtEmail.Text = gv.EmailGV;
                txtTenDangNhap.Text = gv.TenDangNhap;
                txtMatKhau.Text = gv.TAIKHOAN.MatKhau;
                txtTenDangNhap.Enabled = false;
            }
        }

        /// <summary>
        /// Nạp giao diện thành đối tượng
        /// </summary>
        /// <returns></returns>
        private GIANGVIEN LoadGiangVien()
        {
            return new GIANGVIEN()
            {
                MaGV = txtMaGV.Text,
                TenGV = txtTenGV.Text,
                GioiTinhGV = cboGioiTinh.Text,
                SdtGV = txtSDT.Text,
                EmailGV = txtEmail.Text,
                TenDangNhap = txtTenDangNhap.Text
            };
        }

        #region Events

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGiangVienEdit_Load(object sender, EventArgs e)
        {
            LoadUI(gv);
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                if (isInsert)
                {
                    busGiangVien.Insert(LoadGiangVien(), new TAIKHOAN()
                    {
                        TenDangNhap = txtTenDangNhap.Text,
                        MatKhau = txtMatKhau.Text,
                    });

                    MessageBox.Show("Thêm giảng viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    busGiangVien.Update(LoadGiangVien(), new TAIKHOAN()
                    {
                        TenDangNhap = txtTenDangNhap.Text,
                        MatKhau = txtMatKhau.Text,
                    });

                    MessageBox.Show("Sửa giảng viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
