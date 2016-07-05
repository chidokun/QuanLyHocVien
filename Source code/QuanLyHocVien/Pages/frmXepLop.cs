// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmXepLop.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;
using System.Collections.Generic;
using System.Threading;

namespace QuanLyHocVien.Pages
{
    public partial class frmXepLop : Form
    {
        private List<DANGKY> dsChuaCoLop;
        private List<HOCVIEN> dsLopChuaDu;

        public frmXepLop()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Nạp danh sách chưa có lớp lên giao diện
        /// </summary>
        public void LoadDSHVChuaCoLop()
        {
            gridDSHV.Rows.Clear();

            dsChuaCoLop = HocVien.DanhSachChuaCoLop();

            foreach (var i in dsChuaCoLop)
            {
                string[] s = { i.MaHV, i.HOCVIEN.TenHV, i.MaPhieu, i.KHOAHOC.TenKH };
                gridDSHV.Rows.Add(s);
            }
        }

        /// <summary>
        /// Nạp danh sách học viên của lớp lên giao diện
        /// </summary>
        public void LoadDSHVLopChuaDu()
        {
            try
            {
                string maLop = cboLop.SelectedValue.ToString();
                dsLopChuaDu = BangDiem.SelectDSHV(maLop);

                gridDSHVLop.Rows.Clear();
                foreach (var i in dsLopChuaDu)
                {
                    string[] s = { i.MaHV, i.TenHV, i.NgaySinh.ToString(), i.GioiTinhHV, i.SdtHV, i.DiaChi, BangDiem.Select(i.MaHV, maLop).MaPhieu };
                    gridDSHVLop.Rows.Add(s);
                }
            }
            catch
            {
                gridDSHVLop.Rows.Clear();
            }
        }

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalPages.XepLop = null;
        }

        private void frmXepLop_Load(object sender, EventArgs e)
        {
            //load danh sách học viên chưa có lớp
            gridDSHV.AutoGenerateColumns = false;

            LoadDSHVChuaCoLop();

            //load khóa học
            cboKhoa.DataSource = KhoaHoc.SelectAll();
            cboKhoa.DisplayMember = "TenKH";
            cboKhoa.ValueMember = "MaKH";

            //load lớp trống của khóa
            cboLop.DataSource = LopHoc.DanhSachLopTrong(cboKhoa.SelectedValue.ToString());
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";

            LoadDSHVLopChuaDu();

        }

        private void gridDSHV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCongHV.Text = string.Format("Tổng cộng: {0} học viên", gridDSHV.Rows.Count);
        }

        private void gridDSHV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCongHV.Text = string.Format("Tổng cộng: {0} học viên", gridDSHV.Rows.Count);
        }

        private void gridDSHVLop_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCongHVLop.Text = string.Format("Tổng cộng: {0} học viên", gridDSHVLop.Rows.Count);
        }

        private void gridDSHVLop_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCongHVLop.Text = string.Format("Tổng cộng: {0} học viên", gridDSHVLop.Rows.Count);
        }

        private void btnThemVaoLop_Click(object sender, EventArgs e)
        {
            try
            {
                HOCVIEN hv = HocVien.Select(gridDSHV.SelectedRows[0].Cells["clmMaHV"].Value.ToString());

                if (gridDSHVLop.Rows.Count < GlobalSettings.QuyDinh["QD0000"] ||
                MessageBox.Show("Số học viên tối đa của lớp là " + GlobalSettings.QuyDinh["QD0000"] + Environment.NewLine + "Bạn có chắc sẽ thêm?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string[] s = new string[]
                    {
                        hv.MaHV,
                        hv.TenHV,
                        ((DateTime)hv.NgaySinh).ToString("dd/MM/yyyy"),
                        hv.GioiTinhHV,
                        hv.SdtHV,
                        hv.DiaChi,
                        gridDSHV.SelectedRows[0].Cells["clmMaPhieu"].Value.ToString()
                    };

                    gridDSHV.Rows.RemoveAt(gridDSHV.SelectedRows[0].Index);

                    gridDSHVLop.Rows.Add(s);
                }
            }
            catch { }
        }

        private void btnBoKhoiLop_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var i in dsChuaCoLop)
                {
                    if (gridDSHVLop.SelectedRows[0].Cells["clmMaHVLop"].Value.ToString() == i.MaHV)
                    {
                        string[] s = { i.MaHV, i.HOCVIEN.TenHV, i.MaPhieu, i.KHOAHOC.TenKH };
                        gridDSHV.Rows.Add(s);
                        break;
                    }
                }

                gridDSHVLop.Rows.RemoveAt(gridDSHVLop.SelectedRows[0].Index);
            }
            catch { }
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            gridDSHVLop.Rows.Clear();

            LoadDSHVChuaCoLop();
        }

        private void cboKhoa_SelectedValueChanged(object sender, EventArgs e)
        {
            //load lớp trống của khóa
            cboLop.DataSource = LopHoc.DanhSachLopTrong(cboKhoa.SelectedValue.ToString());
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
        }

        private void btnLuuLop_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = gridDSHVLop.Rows;

                foreach (DataGridViewRow i in rows)
                {
                    bool isAdded = false;
                    foreach(var j in dsLopChuaDu)
                    {
                        if(i.Cells["clmMaHVLop"].Value.ToString()==j.MaHV)
                        {
                            isAdded = true;
                            break;
                        }
                    }

                    if(!isAdded)
                    {
                        BangDiem.Insert(new BANGDIEM()
                        {
                            MaHV = i.Cells["clmMaHVLop"].Value.ToString(),
                            MaLop = cboLop.SelectedValue.ToString(),
                            MaPhieu = i.Cells["clmMaPhieuLop"].Value.ToString(),
                            DiemNghe = 0,
                            DiemNoi = 0,
                            DiemDoc = 0,
                            DiemViet = 0
                        });
                    }
                    
                }

                LOPHOC lh = LopHoc.Select(cboLop.SelectedValue.ToString());
                LopHoc.Update(new LOPHOC()
                {
                    MaLop = lh.MaLop,
                    TenLop = lh.TenLop,
                    NgayBD = lh.NgayBD,
                    NgayKT = lh.NgayKT,
                    SiSo = gridDSHVLop.Rows.Count,
                    MaKH = lh.MaKH,
                    DangMo = lh.DangMo
                });

                MessageBox.Show("Đã xếp lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDatLai_Click(sender, e);
                cboKhoa_SelectedValueChanged(sender, e);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboLop_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadDSHVLopChuaDu();
        }

        #endregion


    }
}
