// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmDangNhap.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;
using QuanLyHocVien.Properties;

namespace QuanLyHocVien
{
    public partial class frmDangNhap : Form
    {
        private TaiKhoan busTaiKhoan = new TaiKhoan();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            chkSave.Checked = Settings.Default.Login_IsSaved;

            if(chkSave.Checked)
            {
                txtTenDangNhap.Text = Settings.Default.Login_UserName;
                txtMatKhau.Text = Settings.Default.Login_Password;
            }

            lblNotification.Text = string.Empty;
        }

        private void chkSave_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.Login_IsSaved = chkSave.Checked;
            Settings.Default.Save();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(busTaiKhoan.IsValid(txtTenDangNhap.Text,txtMatKhau.Text))
            {
                TAIKHOAN tk = busTaiKhoan.Select(txtTenDangNhap.Text);
                GlobalSettings.UserID = busTaiKhoan.FullUserID(tk);
                GlobalSettings.UserName = txtTenDangNhap.Text;
                GlobalSettings.UserType = (UserType)busTaiKhoan.FullUserType(tk);

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                lblNotification.Text = "Tên đăng nhập hoặc mật khẩu không chính xác";
                System.Media.SystemSounds.Exclamation.Play();
            }
        }
    }
}
