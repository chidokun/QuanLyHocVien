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
using DataAccess;

namespace QuanLyHocVien
{
    public partial class frmMain : Form
    {
        private NhanVien busNhanVien = new NhanVien();
        public frmMain()
        {
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
            frmDoiMatKhau frm = new frmDoiMatKhau(GlobalSettings.UserName);
            frm.ShowDialog();
        }

        private void btnHVDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau(GlobalSettings.UserName);
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

        private void btnThongKeNoHocVien_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmThongKeNoHocVien frm = new frmThongKeNoHocVien() { Dock = DockStyle.Fill, TopLevel = false };
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }

        private void btnBaoCaoHocVienTheoThang_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmBaoCaoHocVienTheoThang frm = new frmBaoCaoHocVienTheoThang() { Dock = DockStyle.Fill, TopLevel = false };
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }

        private void btnTrangMoDau_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmTrangMoDau frm = new frmTrangMoDau() { Dock = DockStyle.Fill, TopLevel = false };
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }

        private void btnXepLop_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmXepLop frm = new frmXepLop() { Dock = DockStyle.Fill, TopLevel = false };
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }

        private void btnNVDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau(GlobalSettings.UserName);
            frm.ShowDialog();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblCenterName.Text = GlobalSettings.CenterName;
            lblServerName.Text = GlobalSettings.ServerName;
            lblDateTime.Text = DateTime.Now.ToString();
        }

        private void btnThayDoiThongTinNV_Click(object sender, EventArgs e)
        {
            frmThayDoiThongTinNV frm = new frmThayDoiThongTinNV();
            frm.ShowDialog();
        }

        #endregion

        public void ResetRibbonControlStatus()
        {
            btnQuanTriTitle.Enabled = true;
            btnNhanVienTitle.Enabled = true;
            btnHocVienTitle.Enabled = true;
            btnGiangVienTitle.Enabled = true;
            btnTroGiup.Enabled = true;

            btnTiepNhanHocVien.Enabled = true;
            btnLapPhieuGhiDanh.Enabled = true;
            btnBaoCaoHocVienTheoThang.Enabled = true;
            btnThongKeNoHocVien.Enabled = true;
            btnThongKeDiemTheoLop.Enabled = true;
            btnQuanLyDiem.Enabled = true;
            btnXepLop.Enabled = true;
            btnQuanLyHocVien.Enabled = true;
            btnQuanLyNhanVien.Enabled = true;
            btnQuanLyGiangVien.Enabled = true;
            btnQuanLyLopHoc.Enabled = true;
            btnQuanLyKhoaHoc.Enabled = true;
            btnQuanLyHocPhi.Enabled = true;
            btnQuanLyTaiKhoan.Enabled = true;
            btnCaiDatVaQuyDinh.Enabled = false;
            btnQuanLyTaiKhoan.Enabled = false;
            btnThongTinTrungTam.Enabled = false;
        }

        public void LoadGiaoDien()
        {
            ResetRibbonControlStatus();
            PhanQuyen(GlobalSettings.UserType, GlobalSettings.UserName);
            pnlWorkspace.Controls.Clear();

            GlobalSettings.LoadCenterInformation();

            btnTrangMoDau_Click(null, null);
        }
        public void DangNhap()
        {
            this.Hide();
            try
            {
                GlobalSettings.ConnectToDatabase();

                frmDangNhap frm = new frmDangNhap();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadGiaoDien();

                    this.Show();           

                    timer.Start();
                }
            }
            catch
            {
                Reconnect();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void Reconnect()
        {
            frmKetNoiCSDL frm = new frmKetNoiCSDL();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn cần khởi động lại chương trình để thay đổi có hiệu lực." + Environment.NewLine + "Khởi động ngay?", "Khởi động lại", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    Application.Restart();
                else
                    Application.Exit();
            }
            else
            {
                MessageBox.Show("Bạn không thể sử dụng chương trình nếu kết nối cơ sở dữ liệu chưa được thiết lập" + Environment.NewLine + "Hãy chạy lại chương trình vào lần tới để thiết lập lại kết nối cơ sở dữ liệu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }

        /// <summary>
        /// Phân quyền người dùng
        /// </summary>
        /// <param name="userType">Kiểu người dùng</param>
        /// <param name="userName">Tên người dùng</param>
        public void PhanQuyen(UserType userType, string userName)
        {
            switch (userType)
            {
                case UserType.NhanVien:
                    string nvType = busNhanVien.Select(GlobalSettings.UserID).MaLoaiNV;
                    switch (nvType)
                    {
                        //nhân viên ghi danh
                        case "LNV01":
                            btnGiangVienTitle.Enabled = false;
                            btnHocVienTitle.Enabled = false;
                            btnQuanTriTitle.Enabled = false;
                            btnThongKeNoHocVien.Enabled = false;
                            btnThongKeDiemTheoLop.Enabled = false;
                            btnQuanLyDiem.Enabled = false;
                            btnXepLop.Enabled = false;
                            break;
                        //nhân viên học vụ
                        case "LNV02":
                            btnGiangVienTitle.Enabled = false;
                            btnHocVienTitle.Enabled = false;
                            btnTiepNhanHocVien.Enabled = false;
                            btnLapPhieuGhiDanh.Enabled = false;
                            btnBaoCaoHocVienTheoThang.Enabled = false;
                            btnThongKeNoHocVien.Enabled = false;
                            btnQuanLyNhanVien.Enabled = false;
                            btnQuanLyHocPhi.Enabled = false;
                            btnQuanLyTaiKhoan.Enabled = false;
                            btnCaiDatVaQuyDinh.Enabled = false;
                            btnQuanLyTaiKhoan.Enabled = false;
                            btnThongTinTrungTam.Enabled = false;
                            break;
                        //nhân viên kế toán
                        case "LNV03":
                            btnGiangVienTitle.Enabled = false;
                            btnHocVienTitle.Enabled = false;
                            btnTiepNhanHocVien.Enabled = false;
                            btnLapPhieuGhiDanh.Enabled = false;
                            btnBaoCaoHocVienTheoThang.Enabled = false;
                            btnThongKeDiemTheoLop.Enabled = false;
                            btnQuanLyDiem.Enabled = false;
                            btnXepLop.Enabled = false;
                            btnQuanLyHocVien.Enabled = false;
                            btnQuanLyNhanVien.Enabled = false;
                            btnQuanLyGiangVien.Enabled = false;
                            btnQuanLyLopHoc.Enabled = false;
                            btnQuanLyKhoaHoc.Enabled = false;
                            btnQuanLyTaiKhoan.Enabled = false;
                            btnCaiDatVaQuyDinh.Enabled = false;
                            btnQuanLyTaiKhoan.Enabled = false;
                            btnThongTinTrungTam.Enabled = false;
                            break;
                        default:
                            break;                       
                    }

                    break;
                case UserType.HocVien:
                    btnNhanVienTitle.Enabled = false;
                    btnQuanTriTitle.Enabled = false;
                    btnGiangVienTitle.Enabled = false;
                    btnHocVienTitle_Click(this.btnHocVienTitle, null);
                    break;
                case UserType.GiangVien:
                    btnNhanVienTitle.Enabled = false;
                    btnQuanTriTitle.Enabled = false;
                    btnHocVienTitle.Enabled = false;
                    btnGiangVienTitle_Click(this.btnGiangVienTitle, null);
                    break;
                default:
                    break;
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();

            DangNhap();
        }
    }
}
