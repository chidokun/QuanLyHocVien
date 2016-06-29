// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmMain.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Drawing;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;
using QuanLyHocVien.Pages;
using QuanLyHocVien.Popups;
using System.Diagnostics;

namespace QuanLyHocVien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();                   
        }

        #region Ribbon bar

        #region Ribbon Tab

        /// <summary>
        /// Phục hồi màu sắc tiêu đề tab
        /// </summary>
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

        #region Ribbon Button
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

        private void btnTiepNhanHocVien_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            if(GlobalPages.TiepNhanHocVien == null)
                GlobalPages.TiepNhanHocVien = new frmTiepNhanHocVien()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

            pnlWorkspace.Controls.Add(GlobalPages.TiepNhanHocVien);
            GlobalPages.TiepNhanHocVien.Show();
        }

        private void btnLapPhieuGhiDanh_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            if (GlobalPages.LapPhieuGhiDanh == null) 
                GlobalPages.LapPhieuGhiDanh = new frmLapPhieuGhiDanh()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

            pnlWorkspace.Controls.Add(GlobalPages.LapPhieuGhiDanh);
            GlobalPages.LapPhieuGhiDanh.Show();
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

            if (GlobalPages.BangDiem == null)
                GlobalPages.BangDiem = new frmBangDiem()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

            pnlWorkspace.Controls.Add(GlobalPages.BangDiem);
            GlobalPages.BangDiem.Show();
        }

        private void btnXemCacLopDay_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            if (GlobalPages.XemCacLopDay == null)
                GlobalPages.XemCacLopDay = new frmXemCacLopDay()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

            pnlWorkspace.Controls.Add(GlobalPages.XemCacLopDay);
            GlobalPages.XemCacLopDay.Show();
        }

        private void btnHocPhi_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            if (GlobalPages.HocPhiHocVien == null)
                GlobalPages.HocPhiHocVien = new frmHocPhiHocVien()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

            pnlWorkspace.Controls.Add(GlobalPages.HocPhiHocVien);
            GlobalPages.HocPhiHocVien.Show();
        }

        private void btnCacLopDaHoc_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            if (GlobalPages.CacLopDaHoc == null)
                GlobalPages.CacLopDaHoc = new frmCacLopDaHoc()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

            pnlWorkspace.Controls.Add(GlobalPages.CacLopDaHoc);
            GlobalPages.CacLopDaHoc.Show();
        }

        private void btnQuanLyHocVien_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            if (GlobalPages.QuanLyHocVien == null)
                GlobalPages.QuanLyHocVien = new frmQuanLyHocVien()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

            pnlWorkspace.Controls.Add(GlobalPages.QuanLyHocVien);
            GlobalPages.QuanLyHocVien.Show();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            if (GlobalPages.QuanLyNhanVien == null)
                GlobalPages.QuanLyNhanVien = new frmQuanLyNhanVien()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

            pnlWorkspace.Controls.Add(GlobalPages.QuanLyNhanVien);
            GlobalPages.QuanLyNhanVien.Show();
        }

        private void btnQuanLyGiangVien_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            if (GlobalPages.QuanLyGiangVien == null)
                GlobalPages.QuanLyGiangVien = new frmQuanLyGiangVien()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

            pnlWorkspace.Controls.Add(GlobalPages.QuanLyGiangVien);
            GlobalPages.QuanLyGiangVien.Show();
        }

        private void btnQuanLyLopHoc_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            if (GlobalPages.QuanLyLopHoc == null)
                GlobalPages.QuanLyLopHoc = new frmQuanLyLopHoc()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

            pnlWorkspace.Controls.Add(GlobalPages.QuanLyLopHoc);
            GlobalPages.QuanLyLopHoc.Show();
        }

        private void btnQuanLyKhoaHoc_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            if (GlobalPages.QuanLyKhoaHoc == null)
                GlobalPages.QuanLyKhoaHoc = new frmQuanLyKhoaHoc()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

            pnlWorkspace.Controls.Add(GlobalPages.QuanLyKhoaHoc);
            GlobalPages.QuanLyKhoaHoc.Show();
        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            if (GlobalPages.QuanLyTaiKhoan == null)
                GlobalPages.QuanLyTaiKhoan = new frmQuanLyTaiKhoan()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

            pnlWorkspace.Controls.Add(GlobalPages.QuanLyTaiKhoan);
            GlobalPages.QuanLyTaiKhoan.Show();
        }

        private void btnQuanLyDiem_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            if (GlobalPages.QuanLyDiem == null)
                GlobalPages.QuanLyDiem = new frmQuanLyDiem()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

            pnlWorkspace.Controls.Add(GlobalPages.QuanLyDiem);
            GlobalPages.QuanLyDiem.Show();
        }

        private void btnThongKeDiemTheoLop_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            if (GlobalPages.ThongKeDiemTheoLop == null)
                GlobalPages.ThongKeDiemTheoLop = new frmThongKeDiemTheoLop()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

            pnlWorkspace.Controls.Add(GlobalPages.ThongKeDiemTheoLop);
            GlobalPages.ThongKeDiemTheoLop.Show();
        }

        private void btnThongKeNoHocVien_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            if (GlobalPages.ThongKeNoHocVien == null)
                GlobalPages.ThongKeNoHocVien = new frmThongKeNoHocVien()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

            pnlWorkspace.Controls.Add(GlobalPages.ThongKeNoHocVien);
            GlobalPages.ThongKeNoHocVien.Show();
        }

        private void btnBaoCaoHocVienTheoThang_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            if (GlobalPages.BaoCaoHocVienTheoThang == null)
                GlobalPages.BaoCaoHocVienTheoThang = new frmBaoCaoHocVienTheoThang()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

            pnlWorkspace.Controls.Add(GlobalPages.BaoCaoHocVienTheoThang);
            GlobalPages.BaoCaoHocVienTheoThang.Show();
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

            if (GlobalPages.XepLop == null)
                GlobalPages.XepLop = new frmXepLop()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

            pnlWorkspace.Controls.Add(GlobalPages.XepLop);
            GlobalPages.XepLop.Show();
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

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();

            DangNhap();
        }

        private void btnThayDoiQuyDinh_Click(object sender, EventArgs e)
        {
            frmQuyDinh frm = new frmQuyDinh();
            frm.ShowDialog();
        }

        private void btnKetNoiCSDL_Click(object sender, EventArgs e)
        {
            frmKetNoiCSDL frm = new frmKetNoiCSDL();
            frm.ShowDialog();
        }

        private void btnTroGiup_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/chidokun/QuanLyHocVien/wiki");
        }

        private void btnQuanLyHocPhi_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            if (GlobalPages.QuanLyHocPhi == null)
                GlobalPages.QuanLyHocPhi = new frmQuanLyHocPhi()
                {
                    Dock = DockStyle.Fill,
                    TopLevel = false
                };

            pnlWorkspace.Controls.Add(GlobalPages.QuanLyHocPhi);
            GlobalPages.QuanLyHocPhi.Show();
        }

        #endregion

        /// <summary>
        /// Phục hồi trạng thái enable của Ribbon control
        /// </summary>
        public void ResetRibbonControlStatus()
        {
            btnQuanTriTitle.Visible = true;
            btnNhanVienTitle.Visible = true;
            btnHocVienTitle.Visible = true;
            btnGiangVienTitle.Visible = true;
            btnTroGiup.Visible = true;

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
            btnThayDoiQuyDinh.Enabled = true;
            btnQuanLyTaiKhoan.Enabled = true;
            btnThongTinTrungTam.Enabled = true;
        }

        #endregion

        #region Đăng nhập và khởi động

        /// <summary>
        /// Đăng nhập vào phần mềm
        /// </summary>
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

        /// <summary>
        /// Kết nối lại cơ sở dữ liệu
        /// </summary>
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
                    string nvType = NhanVien.Select(GlobalSettings.UserID).MaLoaiNV;
                    switch (nvType)
                    {
                        //nhân viên ghi danh
                        case "LNV01":
                            btnGiangVienTitle.Visible = false;
                            btnHocVienTitle.Visible = false;
                            btnQuanTriTitle.Visible = false;
                            btnThongKeNoHocVien.Enabled = false;
                            btnThongKeDiemTheoLop.Enabled = false;
                            btnQuanLyDiem.Enabled = false;
                            btnXepLop.Enabled = false;
                            btnNhanVienTitle_Click(btnNhanVienTitle, null);
                            break;
                        //nhân viên học vụ
                        case "LNV02":
                            btnGiangVienTitle.Visible = false;
                            btnHocVienTitle.Visible = false;
                            btnTiepNhanHocVien.Enabled = false;
                            btnLapPhieuGhiDanh.Enabled = false;
                            btnBaoCaoHocVienTheoThang.Enabled = false;
                            btnThongKeNoHocVien.Enabled = false;
                            btnQuanLyNhanVien.Enabled = false;
                            btnQuanLyHocPhi.Enabled = false;
                            btnQuanLyTaiKhoan.Enabled = false;
                            btnThayDoiQuyDinh.Enabled = false;
                            btnQuanLyTaiKhoan.Enabled = false;
                            btnThongTinTrungTam.Enabled = false;
                            btnNhanVienTitle_Click(btnNhanVienTitle, null);
                            break;
                        //nhân viên kế toán
                        case "LNV03":
                            btnGiangVienTitle.Visible = false;
                            btnHocVienTitle.Visible = false;
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
                            btnThayDoiQuyDinh.Enabled = false;
                            btnQuanLyTaiKhoan.Enabled = false;
                            btnThongTinTrungTam.Enabled = false;
                            btnNhanVienTitle_Click(btnNhanVienTitle, null);
                            break;
                        default:
                            btnHocVienTitle.Visible = false;
                            btnGiangVienTitle.Visible = false;
                            btnQuanTriTitle_Click(btnQuanTriTitle, null);
                            break;
                    }
                    break;
                case UserType.HocVien:
                    btnNhanVienTitle.Visible = false;
                    btnQuanTriTitle.Visible = false;
                    btnGiangVienTitle.Visible = false;
                    btnHocVienTitle_Click(this.btnHocVienTitle, null);
                    break;
                case UserType.GiangVien:
                    btnNhanVienTitle.Visible = false;
                    btnQuanTriTitle.Visible = false;
                    btnHocVienTitle.Visible = false;
                    btnGiangVienTitle_Click(this.btnGiangVienTitle, null);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Nạp giao diện phần mềm
        /// </summary>
        public void LoadGiaoDien()
        {
            ResetRibbonControlStatus();
            PhanQuyen(GlobalSettings.UserType, GlobalSettings.UserName);
            pnlWorkspace.Controls.Clear();

            if (GlobalSettings.UserType == UserType.NhanVien)
                GlobalPages.LoadEssentialPages();

            GlobalSettings.LoadCenterInformation();

            btnTrangMoDau_Click(null, null);
        }

        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            DangNhap();
        }
    }
}
