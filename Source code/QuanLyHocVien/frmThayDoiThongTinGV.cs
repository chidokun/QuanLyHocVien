// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmThayDoiThongTinGV.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;

namespace QuanLyHocVien
{
    public partial class frmThayDoiThongTinGV : Form
    {
        private GiangVien busGiangVien = new GiangVien();

        public frmThayDoiThongTinGV()
        {
            InitializeComponent();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThayDoiThongTinGV_Load(object sender, EventArgs e)
        {
            GIANGVIEN gv = busGiangVien.Select(GlobalSettings.UserID);
            txtMaGV.Text = gv.MaGV;
            txtTenGV.Text = gv.TenGV;
            cboGioiTinh.Text = gv.GioiTinhGV;
            txtEmail.Text = gv.EmailGV;
            txtSDT.Text = gv.SdtGV;
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
                busGiangVien.Update(new GIANGVIEN()
                {
                    MaGV = txtMaGV.Text,
                    TenGV = txtTenGV.Text,
                    GioiTinhGV = cboGioiTinh.Text,
                    EmailGV = txtEmail.Text,
                    SdtGV = txtSDT.Text
                });

                MessageBox.Show("Cập nhật thông tin giảng viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
