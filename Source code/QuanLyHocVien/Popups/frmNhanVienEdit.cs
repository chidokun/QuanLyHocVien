// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmNhanVienEdit.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;

namespace QuanLyHocVien.Popups
{
    public partial class frmNhanVienEdit : Form
    {
        private NHANVIEN nv;
        private bool isInsert = false;

        public frmNhanVienEdit(NHANVIEN nv)
        {
            InitializeComponent();
            this.nv = nv;
            isInsert = nv == null;
        }

        /// <summary>
        /// Nạp nhân viên lên giao diện
        /// </summary>
        /// <param name="nv"></param>
        public void LoadUI(NHANVIEN nv)
        {
            if (nv == null)
            {
                txtMaNV.Text = NhanVien.AutoGenerateId();
            }
            else
            {
                txtMaNV.Text = nv.MaNV;
                txtTenNV.Text = nv.TenNV;
                txtSDT.Text = nv.SdtNV;
                txtEmail.Text = nv.EmailNV;
                cboLoaiNV.SelectedValue = nv.MaLoaiNV;
                txtTenDangNhap.Text = nv.TenDangNhap;
                txtMatKhau.Text = nv.TAIKHOAN.MatKhau;
                txtTenDangNhap.Enabled = false;
            }
        }

        /// <summary>
        /// Nạp giao diện thành đối tượng
        /// </summary>
        /// <returns></returns>
        private NHANVIEN LoadNhanVien()
        {
            return new NHANVIEN()
            {
                MaNV = txtMaNV.Text,
                TenNV = txtTenNV.Text,
                SdtNV = txtSDT.Text,
                EmailNV = txtEmail.Text,
                MaLoaiNV = cboLoaiNV.SelectedValue.ToString(),
                TenDangNhap = txtTenDangNhap.Text
            };
        }

        /// <summary>
        /// Kiểm tra hợp lệ
        /// </summary>
        public void ValidateLuu()
        {
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
                throw new ArgumentException("Họ và tên nhân viên không được trống");
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
                throw new ArgumentException("Số điện thoại không được trống");
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
                throw new ArgumentException("Email không được trống");
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
                throw new ArgumentException("Tên đăng nhập không được trống");
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                throw new ArgumentException("Mật khẩu không được trống");
        }

        #region Events

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhanVienEdit_Load(object sender, EventArgs e)
        {
            //load loại nhân viên
            cboLoaiNV.DataSource = LoaiNV.SelectAll();
            cboLoaiNV.DisplayMember = "TenLoaiNV";
            cboLoaiNV.ValueMember = "MaLoaiNV";

            LoadUI(nv);
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateLuu();

                if (isInsert)
                {
                    NhanVien.Insert(LoadNhanVien(), new TAIKHOAN()
                    {
                        TenDangNhap = txtTenDangNhap.Text,
                        MatKhau = txtMatKhau.Text,
                    });

                    MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    NhanVien.Update(LoadNhanVien(), new TAIKHOAN()
                    {
                        TenDangNhap = txtTenDangNhap.Text,
                        MatKhau = txtMatKhau.Text,
                    });

                    MessageBox.Show("Sửa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
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

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}
