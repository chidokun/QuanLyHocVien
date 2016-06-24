// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmDoiMatKhau.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;

namespace QuanLyHocVien.Popups
{
    public partial class frmDoiMatKhau : Form
    {
        private string UserName { get; set; }
        private TaiKhoan busTaiKhoan = new TaiKhoan();
        private TAIKHOAN currentUser;

        public frmDoiMatKhau(string userName)
        {
            InitializeComponent();
            UserName = userName;
            currentUser = busTaiKhoan.Select(UserName);
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

            lblUserName.Text = busTaiKhoan.FullUserName(currentUser);

            txtTenDangNhap.Text = UserName;
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMatKhauCu.Text == currentUser.MatKhau)
                {
                    if (!string.IsNullOrEmpty(txtMatKhauMoi.Text) && txtMatKhauMoi.Text == txtMatKhauMoiAgain.Text)
                    {
                        currentUser.MatKhau = txtMatKhauMoi.Text;
                        busTaiKhoan.Update(currentUser);

                        MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Mật khẩu mới trống hoặc không khớp", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Mật khẩu cũ không chính xác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
