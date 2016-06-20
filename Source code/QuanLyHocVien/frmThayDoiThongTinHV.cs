// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmThayDoiThongTinHV.cs"
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
    public partial class frmThayDoiThongTinHV : Form
    {
        private HocVien busHocVien = new HocVien();
        private HOCVIEN hv;

        public frmThayDoiThongTinHV()
        {
            InitializeComponent();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThayDoiThongTinHV_Load(object sender, EventArgs e)
        {
            hv = busHocVien.Select(GlobalSettings.UserID);

            txtMaHV.Text = hv.MaHV;
            txtTenHV.Text = hv.TenHV;
            dateNgaySinh.Value = (DateTime)hv.NgaySinh;
            cboGioiTinh.Text = hv.GioiTinhHV;
            txtDiaChi.Text = hv.DiaChi;
            txtSDT.Text = hv.SdtHV;
            txtEmail.Text = hv.EmailHV;
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
                busHocVien.Update(new HOCVIEN()
                {
                    MaHV = txtMaHV.Text,
                    TenHV = txtTenHV.Text,
                    GioiTinhHV = cboGioiTinh.Text,
                    NgaySinh = dateNgaySinh.Value,
                    DiaChi = txtDiaChi.Text,
                    SdtHV = txtSDT.Text,
                    EmailHV = txtEmail.Text,
                    MaLoaiHV = hv.MaLoaiHV
                });

                MessageBox.Show("Cập nhật thông tin học viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

