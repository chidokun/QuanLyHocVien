// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmThongTinTrungTam.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;

namespace QuanLyHocVien
{
    public partial class frmThongTinTrungTam : Form
    {
        private ChiTietTrungTam busCTTT = new ChiTietTrungTam();

        public frmThongTinTrungTam()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Chuyển giao diện thành đối tượng
        /// </summary>
        /// <returns></returns>
        public CHITIETTRUNGTAM LoadChiTiet()
        {
            return new CHITIETTRUNGTAM()
            {
                TenTT = txtTenTrungTam.Text,
                DiaChiTT = txtDiaChi.Text,
                SdtTT = txtSDT.Text,
                EmailTT = txtEmail.Text,
                Website = txtWebsite.Text,
            };
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThongTinTrungTam_Load(object sender, EventArgs e)
        {
            var item = busCTTT.Select();
            txtTenTrungTam.Text = item.TenTT;
            txtDiaChi.Text = item.DiaChiTT;
            txtSDT.Text = item.SdtTT;
            txtEmail.Text = item.EmailTT;
            txtWebsite.Text = item.Website;
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
                busCTTT.Update(LoadChiTiet());

                MessageBox.Show("Thay đổi thông tin trung tâm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
