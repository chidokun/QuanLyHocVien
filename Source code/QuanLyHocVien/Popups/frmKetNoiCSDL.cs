// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmKetNoiCSDL.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;

namespace QuanLyHocVien.Popups
{
    public partial class frmKetNoiCSDL : Form
    {
        private string connectionString;

        public frmKetNoiCSDL()
        {
            InitializeComponent();
        }

        #region Events

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            connectionString = string.Format("Data Source={0};Initial Catalog=master;", txtTenServer.Text);

            if (cboKieuXacThuc.SelectedIndex == 0)
                connectionString += "Integrated Security=True;";
            else
                connectionString += string.Format("User Id={0};Password={1};", txtTenDangNhap.Text, txtMatKhau.Text);

            try
            {
                cboDatabase.DataSource = GlobalSettings.GetDatabaseList(connectionString);

                MessageBox.Show("Kết nối thành công!" + Environment.NewLine + "Vui lòng chọn cơ sở dữ liệu trong danh sách bên dưới.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDatabase.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Kết nối thất bại!" + Environment.NewLine + "Vui lòng thử lại một lần nữa.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmKetNoiCSDL_Load(object sender, EventArgs e)
        {
            cboKieuXacThuc.Items.AddRange(new string[]
            {
                "Xác thực của Windows",
                "Xác thực của SQL Server"
            });

            cboKieuXacThuc.SelectedIndex = 0;

            //load temp
            txtTenServer.Text = GlobalSettings.ServerName;
            cboDatabase.Text = GlobalSettings.ServerCatalog;
        }

        private void cboKieuXacThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenDangNhap.Enabled = txtMatKhau.Enabled = cboKieuXacThuc.SelectedIndex == 1;
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            connectionString = string.Format("Data Source = {0}; Initial Catalog = {1}; ", txtTenServer.Text, cboDatabase.Text);

            if (cboKieuXacThuc.SelectedIndex == 0)
                connectionString += "Integrated Security = True; ";
            else
                connectionString += string.Format("User Id = {0}; Password = {1}; ", txtTenDangNhap.Text, txtMatKhau.Text);

            GlobalSettings.ConnectionString = connectionString;
            GlobalSettings.ServerName = txtTenServer.Text;
            GlobalSettings.ServerCatalog = cboDatabase.Text;

            GlobalSettings.SaveDatabaseConnection();

            MessageBox.Show("Đã lưu cài đặt kết nối cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion
    }
}
