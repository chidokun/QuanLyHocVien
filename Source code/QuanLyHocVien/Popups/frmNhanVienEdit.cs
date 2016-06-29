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
        private LoaiNV busLoaiNV = new LoaiNV();
        private NhanVien busNhanVien = new NhanVien();
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
                txtMaNV.Text = busNhanVien.AutoGenerateId();
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

        #region Events

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNhanVienEdit_Load(object sender, EventArgs e)
        {
            //load loại nhân viên
            cboLoaiNV.DataSource = busLoaiNV.SelectAll();
            cboLoaiNV.DisplayMember = "TenLoaiNV";
            cboLoaiNV.ValueMember = "MaLoaiNV";

            LoadUI(nv);
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                if (isInsert)
                {
                    busNhanVien.Insert(LoadNhanVien(), new TAIKHOAN()
                    {
                        TenDangNhap = txtTenDangNhap.Text,
                        MatKhau = txtMatKhau.Text,
                    });

                    MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    busNhanVien.Update(LoadNhanVien(), new TAIKHOAN()
                    {
                        TenDangNhap = txtTenDangNhap.Text,
                        MatKhau = txtMatKhau.Text,
                    });

                    MessageBox.Show("Sửa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
