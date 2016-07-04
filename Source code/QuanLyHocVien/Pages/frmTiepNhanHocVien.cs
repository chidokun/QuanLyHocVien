// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmTiepNhanHocVien.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;
using System.Threading;

namespace QuanLyHocVien.Pages
{
    public partial class frmTiepNhanHocVien : Form
    {
        private bool isInsert = false;
        private HOCVIEN hocVien;

        public frmTiepNhanHocVien()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Khóa điều khiển các control
        /// </summary>
        public void LockPanelControl()
        {
            txtHoTen.Enabled = false;
            dateNgaySinh.Enabled = false;
            cboGioiTinh.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;
            txtEmail.Enabled = false;
            cboLoaiHV.Enabled = false;
            txtMatKhau.Enabled = false;
            btnLuuThongTin.Enabled = false;
            btnHuyBo.Enabled = false;
        }

        /// <summary>
        /// Mở khóa điều khiển các control
        /// </summary>
        public void UnlockPanelControl()
        {
            txtHoTen.Enabled = true;
            dateNgaySinh.Enabled = true;
            cboGioiTinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            cboLoaiHV.Enabled = true;
            txtMatKhau.Enabled = true;
            btnLuuThongTin.Enabled = true;
            btnHuyBo.Enabled = true;
        }

        /// <summary>
        /// Đặt lại giá trị của các control trong panel
        /// </summary>
        public void ResetPanelControl()
        {
            txtMaHV.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            dateNgaySinh.Value = dateNgaySinh.MaxDate;
            cboGioiTinh.SelectedIndex = 0;
            txtDiaChi.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cboLoaiHV.SelectedIndex = 0;
            txtTenDangNhap.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
        }

        /// <summary>
        /// Nạp học viên lên giao diện
        /// </summary>
        /// <param name="hv"></param>
        public void LoadPanelControl(HOCVIEN hv = null)
        {
            try
            {
                if (hv == null)
                {
                    ResetPanelControl();
                    txtMaHV.Text = HocVien.AutoGenerateId();
                    txtTenDangNhap.Text = txtMaHV.Text;
                    cboLoaiHV_SelectedValueChanged(null, null);
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
                    txtTenDangNhap.Text = hv.TenDangNhap;
                    txtMatKhau.Text = hv.TAIKHOAN != null ? hv.TAIKHOAN.MatKhau : string.Empty;
                }
            }
            catch
            {
                ResetPanelControl();
                LockPanelControl();
            }

        }

        /// <summary>
        /// Nạp giao diện thành học viên
        /// </summary>
        /// <returns></returns>
        public HOCVIEN LoadHocVien()
        {
            hocVien = new HOCVIEN()
            {
                MaHV = txtMaHV.Text,
                TenHV = txtHoTen.Text,
                NgaySinh = dateNgaySinh.Value,
                GioiTinhHV = cboGioiTinh.Text,
                DiaChi = txtDiaChi.Text,
                SdtHV = txtSDT.Text,
                EmailHV = txtEmail.Text,
                MaLoaiHV = (string)cboLoaiHV.SelectedValue,
                NgayTiepNhan = DateTime.Now,
                TenDangNhap = (string)cboLoaiHV.SelectedValue == "LHV00" ? null : txtTenDangNhap.Text
            };
            return hocVien;
        }

        /// <summary>
        /// Nạp loại học viên
        /// </summary>
        public void InitializeLoaiHV()
        {
            cboLoaiHV.DataSource = LoaiHV.SelectAll();
            cboLoaiHV.DisplayMember = "TenLoaiHV";
            cboLoaiHV.ValueMember = "MaLoaiHV";
        }

        /// <summary>
        /// Nạp danh sách học viên
        /// </summary>
        public void InitializeHocVien()
        {
            gridDSHV.AutoGenerateColumns = false;

            Thread th = new Thread(() =>
            {
                object dshv = HocVien.SelectAll();

                gridDSHV.Invoke((MethodInvoker)delegate
                {
                    gridDSHV.DataSource = dshv;
                });
            });

            th.Start();
        }

        /// <summary>
        /// Kiểm tra thông tin nhập vào có đầy đủ và hợp lệ
        /// </summary>
        public void ValidateLuu()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                throw new ArgumentException("Họ và tên không được trống");
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
                throw new ArgumentException("Địa chỉ không được trống");
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
                throw new ArgumentException("Số điện thoại không được trống");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalPages.TiepNhanHocVien = null;
        }

        private void frmTiepNhanHocVien_Load(object sender, EventArgs e)
        {
            dateNgaySinh.MaxDate = DateTime.Now;

            LockPanelControl();
            InitializeLoaiHV();
            InitializeHocVien();          
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UnlockPanelControl();
            isInsert = true;
            LoadPanelControl();
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateLuu();

                if (isInsert)
                {
                    HocVien.Insert(LoadHocVien(), new TAIKHOAN()
                    {
                        TenDangNhap = txtTenDangNhap.Text,
                        MatKhau = txtMatKhau.Text,
                    });

                    InitializeHocVien();
                    MessageBox.Show("Thêm học viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    HocVien.Update(LoadHocVien(), new TAIKHOAN()
                    {
                        TenDangNhap = txtTenDangNhap.Text,
                        MatKhau = txtMatKhau.Text,
                    });

                    InitializeHocVien();
                    MessageBox.Show("Sửa học viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridDSHV_Click(object sender, EventArgs e)
        {
            LockPanelControl();
            hocVien = HocVien.Select(gridDSHV.SelectedRows[0].Cells["clmMaHV"].Value.ToString());
            LoadPanelControl(hocVien);
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            LockPanelControl();
            gridDSHV_Click(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            UnlockPanelControl();
            isInsert = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HocVien.Delete(txtMaHV.Text);

                    MessageBox.Show("Xóa học viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InitializeHocVien();
                    ResetPanelControl();
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridDSHV_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
        }

        private void cboLoaiHV_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLoaiHV.SelectedValue.ToString() == "LHV00")
            {
                txtTenDangNhap.Text = string.Empty;
                txtMatKhau.Text = string.Empty;
                txtMatKhau.Enabled = false;
            }
            else
            {
                txtTenDangNhap.Text = txtMaHV.Text;
                txtMatKhau.Text = txtMaHV.Text;
                txtMatKhau.Enabled = true;
            }
        }

        private void gridDSHV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} học viên ({1} học viên chính thức và {2} học viên tiềm năng)",
                HocVien.Count(), HocVien.CountChinhThuc(), HocVien.CountTiemNang());
        }

        private void gridDSHV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} học viên ({1} học viên chính thức và {2} học viên tiềm năng)",
                HocVien.Count(), HocVien.CountChinhThuc(), HocVien.CountTiemNang());
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
