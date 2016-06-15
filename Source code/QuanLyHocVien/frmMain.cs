// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmMain.cs"
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


namespace QuanLyHocVien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            BusinessLogic.GlobalSettings.LoadDatabase();
            InitializeComponent();
        }

        #region Ribbon bar
        private void ResetColorTabTitle()
        {
            btnNhanVienTitle.BackColor = Color.White;
            btnGiangVienTitle.BackColor = Color.White;
            btnHocVienTitle.BackColor = Color.White;
            btnQuanTriTitle.BackColor = Color.White;
            btnTroGiupTitle.BackColor = Color.White;
        }

        private void btnNhanVienTitle_Click(object sender, EventArgs e)
        {
            tabRibbon.SelectedTab = tabRibbon.TabPages["tabNhanVien"];

            ResetColorTabTitle();
            ((Button)sender).BackColor = Color.FromArgb(233, 233, 233);
        }

        private void btnGiangVienTitle_Click(object sender, EventArgs e)
        {
            tabRibbon.SelectedTab = tabRibbon.TabPages["tabGiangVien"];

            ResetColorTabTitle();
            ((Button)sender).BackColor = Color.FromArgb(233, 233, 233);
        }

        private void btnHocVienTitle_Click(object sender, EventArgs e)
        {
            tabRibbon.SelectedTab = tabRibbon.TabPages["tabHocVien"];

            ResetColorTabTitle();
            ((Button)sender).BackColor = Color.FromArgb(233, 233, 233);
        }

        private void btnQuanTriTitle_Click(object sender, EventArgs e)
        {
            tabRibbon.SelectedTab = tabRibbon.TabPages["tabQuanTri"];

            ResetColorTabTitle();
            ((Button)sender).BackColor = Color.FromArgb(233, 233, 233);
        }

        private void btnTroGiupTitle_Click(object sender, EventArgs e)
        {
            tabRibbon.SelectedTab = tabRibbon.TabPages["tabTroGiup"];

            ResetColorTabTitle();
            ((Button)sender).BackColor = Color.FromArgb(233, 233, 233);
        }


        #endregion

        private void btnThongTinTrungTam_Click(object sender, EventArgs e)
        {
            frmThongTinTrungTam frm = new frmThongTinTrungTam();
            frm.ShowDialog();
        }

        private void btnThongTinPhanMem_Click(object sender, EventArgs e)
        {
            frmThongTinPhanMem frm = new frmThongTinPhanMem();
            frm.ShowDialog();
        }

        private void btnCaiDatVaQuyDinh_Click(object sender, EventArgs e)
        {
            frmCaiDatVaQuyDinh frm = new frmCaiDatVaQuyDinh();
            frm.ShowDialog();
        }

        private void btnTiepNhanHocVien_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmTiepNhanHocVien frm = new frmTiepNhanHocVien() { Dock = DockStyle.Fill, TopLevel = false };
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }

        private void btnLapPhieuGhiDanh_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmLapPhieuGhiDanh frm = new frmLapPhieuGhiDanh() { Dock = DockStyle.Fill, TopLevel = false };
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }

        private void btnGVDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau(GlobalSettings.CurrentUser);
            frm.ShowDialog();
        }

        private void btnHVDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau(GlobalSettings.CurrentUser);
            frm.ShowDialog();
        }

        private void btnGVThayDoiThongTin_Click(object sender, EventArgs e)
        {
            frmThayDoiThongTinGV frm = new frmThayDoiThongTinGV();
            frm.ShowDialog();
        }

        private void btnHVThayDoiThongTin_Click(object sender, EventArgs e)
        {
            frmThayDoiThongTinHV frm = new frmThayDoiThongTinHV();
            frm.ShowDialog();
        }

        private void btnBangDiem_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmBangDiem frm = new frmBangDiem() { Dock = DockStyle.Fill, TopLevel = false };
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }

        private void btnXemCacLopDay_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmXemCacLopDay frm = new frmXemCacLopDay() { Dock = DockStyle.Fill, TopLevel = false };
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }

        private void btnHocPhi_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmHocPhiHocVien frm = new frmHocPhiHocVien() { Dock = DockStyle.Fill, TopLevel = false };
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }

        private void btnCacLopDaHoc_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmCacLopDaHoc frm = new frmCacLopDaHoc() { Dock = DockStyle.Fill, TopLevel = false };
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }

        private void btnQuanLyHocVien_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmQuanLyHocVien frm = new frmQuanLyHocVien() { Dock = DockStyle.Fill, TopLevel = false };
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmQuanLyNhanVien frm = new frmQuanLyNhanVien() { Dock = DockStyle.Fill, TopLevel = false };
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }

        private void btnQuanLyGiangVien_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmQuanLyGiangVien frm = new frmQuanLyGiangVien() { Dock = DockStyle.Fill, TopLevel = false };
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }

        private void btnQuanLyLopHoc_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmQuanLyLopHoc frm = new frmQuanLyLopHoc() { Dock = DockStyle.Fill, TopLevel = false };
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }

        private void btnQuanLyKhoaHoc_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmQuanLyKhoaHoc frm = new frmQuanLyKhoaHoc() { Dock = DockStyle.Fill, TopLevel = false };
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmQuanLyTaiKhoan frm = new frmQuanLyTaiKhoan() { Dock = DockStyle.Fill, TopLevel = false };
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }

        private void btnQuanLyDiem_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmQuanLyDiem frm = new frmQuanLyDiem() { Dock = DockStyle.Fill, TopLevel = false };
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }

        private void btnThongKeDiemTheoLop_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmThongKeDiemTheoLop frm = new frmThongKeDiemTheoLop() { Dock = DockStyle.Fill, TopLevel = false };
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }
    }
}
