// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmHocVienEdit.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;

namespace QuanLyHocVien.Popups
{
    public partial class frmHocVienEdit : Form
    {
        private HOCVIEN hv;
        private bool isInsert = true;

        public frmHocVienEdit(HOCVIEN hv)
        {
            InitializeComponent();
            this.hv = hv;
            isInsert = hv == null;
        }

        /// <summary>
        /// Nạp học viên lên giao diện
        /// </summary>
        /// <param name="hv"></param>
        public void LoadUI(HOCVIEN hv)
        {
            if (hv == null)
            {
                txtMaHV.Text = HocVien.AutoGenerateId();
                cboGioiTinh.SelectedIndex = 0;
            }
            else
            {
                txtMaHV.Text = hv.MaHV;
                txtHoTen.Text = hv.TenHV;
                dateNgaySinh.Value = (DateTime)hv.NgaySinh;
                cboGioiTinh.Text = hv.GioiTinhHV;
                txtDiaChi.Text = hv.DiaChi;
                txtSDT.Text = hv.SdtHV;
                txtEmail.Text = hv.EmailHV;
                cboLoaiHV.SelectedValue = hv.MaLoaiHV;

                if (hv.MaLoaiHV == "LHV01")
                {
                    cboLoaiHV.Enabled = false;
                    txtMatKhau.Enabled = false;
                }

                if (hv.TenDangNhap != null)
                {
                    txtTenDangNhap.Text = hv.TenDangNhap;
                    txtMatKhau.Text = hv.TAIKHOAN.MatKhau;
                }
                else
                    txtTenDangNhap.Text = txtMatKhau.Text = string.Empty;
            }
        }

        /// <summary>
        /// Nạp giao diện thành đối tượng
        /// </summary>
        /// <returns></returns>
        private HOCVIEN LoadHocVien()
        {
            return new HOCVIEN()
            {
                MaHV = txtMaHV.Text,
                TenHV = txtHoTen.Text,
                NgaySinh = dateNgaySinh.Value,
                GioiTinhHV = cboGioiTinh.Text,
                DiaChi = txtDiaChi.Text,
                SdtHV = txtSDT.Text,
                EmailHV = txtEmail.Text,
                MaLoaiHV = cboLoaiHV.SelectedValue.ToString(),
                NgayTiepNhan = DateTime.Now,
                TenDangNhap = (string)cboLoaiHV.SelectedValue == "LHV00" ? null : txtTenDangNhap.Text
            };
        }

        #region Events

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHocVienEdit_Load(object sender, EventArgs e)
        {
            cboLoaiHV.DataSource = LoaiHV.SelectAll();
            cboLoaiHV.DisplayMember = "TenLoaiHV";
            cboLoaiHV.ValueMember = "MaLoaiHV";

            LoadUI(hv);
        }

        private void cboLoaiHV_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLoaiHV.SelectedValue.ToString() != "LHV00")
            {
                txtMatKhau.Enabled = true;
                txtTenDangNhap.Text = txtMaHV.Text;
                txtMatKhau.Text = string.Empty;
            }
            else
            {
                txtMatKhau.Enabled = false;
                txtTenDangNhap.Text = string.Empty;
                txtMatKhau.Text = string.Empty;
            }
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                if (isInsert)
                {
                    HocVien.Insert(LoadHocVien(), new TAIKHOAN()
                    {
                        TenDangNhap = txtTenDangNhap.Text,
                        MatKhau = txtMatKhau.Text,
                    });

                    MessageBox.Show("Thêm học viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    HocVien.Update(LoadHocVien(), new TAIKHOAN()
                    {
                        TenDangNhap = txtTenDangNhap.Text,
                        MatKhau = txtMatKhau.Text,
                    });

                    MessageBox.Show("Sửa học viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
