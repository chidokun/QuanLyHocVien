// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmQuanLyKhoaHoc.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;

namespace QuanLyHocVien.Pages
{
    public partial class frmQuanLyKhoaHoc : Form
    {
        private KhoaHoc busKhoaHoc = new KhoaHoc();
        private bool isInsert = false;

        public frmQuanLyKhoaHoc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Khóa điều khiển các control
        /// </summary>
        public void LockPanelControl()
        {
            txtMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            numHocPhi.Enabled = false;
            numDiemNghe.Enabled = false;
            numDiemNoi.Enabled = false;
            numDiemDoc.Enabled = false;
            numDiemViet.Enabled = false;
            btnLuuThongTin.Enabled = false;
            btnHuyBo.Enabled = false;
        }

        /// <summary>
        /// Mở khóa điều khiển các control
        /// </summary>
        public void UnlockPanelControl()
        {
            txtTenKH.Enabled = true;
            numHocPhi.Enabled = true;
            numDiemNghe.Enabled = true;
            numDiemNoi.Enabled = true;
            numDiemDoc.Enabled = true;
            numDiemViet.Enabled = true;
            btnLuuThongTin.Enabled = true;
            btnHuyBo.Enabled = true;
        }

        /// <summary>
        /// Đặt lại giá trị của các control trong panel
        /// </summary>
        public void ResetPanelControl()
        {
            txtMaKH.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            numHocPhi.Value = 0;
            numDiemNghe.Value = 0;
            numDiemNoi.Value = 0;
            numDiemDoc.Value = 0;
            numDiemViet.Value = 0;
        }

        /// <summary>
        /// Nạp khóa học lên giao diện
        /// </summary>
        /// <param name="kh">Khóa học</param>
        public void LoadUI(KHOAHOC kh)
        {
            txtMaKH.Text = kh.MaKH;
            txtTenKH.Text = kh.TenKH;
            numHocPhi.Value = (decimal)kh.HocPhi;
            numDiemNghe.Value = (decimal)kh.HeSoNghe;
            numDiemNoi.Value = (decimal)kh.HeSoNoi;
            numDiemDoc.Value = (decimal)kh.HeSoDoc;
            numDiemViet.Value = (decimal)kh.HeSoViet;
        }

        /// <summary>
        /// Nạp giao diện xuống khóa học
        /// </summary>
        /// <returns></returns>
        public KHOAHOC LoadKhoaHoc()
        {
            return new KHOAHOC()
            {
                MaKH = txtMaKH.Text,
                TenKH = txtTenKH.Text,
                HocPhi = numHocPhi.Value,
                HeSoNghe = (int?)numDiemNghe.Value,
                HeSoNoi = (int?)numDiemNoi.Value,
                HeSoDoc = (int?)numDiemDoc.Value,
                HeSoViet = (int?)numDiemViet.Value
            };
        }

        public void LoadGridKhoaHoc()
        {
            gridKH.DataSource = busKhoaHoc.SelectAll();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            gridKH_Click(sender, e);
        }

        private void frmQuanLyKhoaHoc_Load(object sender, EventArgs e)
        {
            gridKH.AutoGenerateColumns = false;

            LockPanelControl();
            LoadGridKhoaHoc();
            gridKH_Click(sender, e);         
        }

        private void gridKH_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} khóa học", gridKH.Rows.Count);
        }

        private void gridKH_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} khóa học", gridKH.Rows.Count);
        }

        private void gridKH_Click(object sender, EventArgs e)
        {
            LockPanelControl();

            try
            {
                LoadUI(busKhoaHoc.Select(gridKH.SelectedRows[0].Cells["clmMaKH"].Value.ToString()));
            }
            catch
            {
                ResetPanelControl();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UnlockPanelControl();
            ResetPanelControl();
            txtMaKH.Text = busKhoaHoc.AutoGenerateId();
            isInsert = true;
        }

        private void gridKH_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(sender, e);
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
                    busKhoaHoc.Delete(gridKH.SelectedRows[0].Cells["clmMaKH"].Value.ToString());

                    MessageBox.Show("Xóa khóa học thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridKhoaHoc();
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                if (isInsert)
                {
                    busKhoaHoc.Insert(LoadKhoaHoc());

                    MessageBox.Show("Thêm khóa học thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    busKhoaHoc.Update(LoadKhoaHoc());

                    MessageBox.Show("Sửa khóa học thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadGridKhoaHoc();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
