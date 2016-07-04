// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmLapPhieuGhiDanh.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;
using System.Threading;
using QuanLyHocVien.Reports;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;

namespace QuanLyHocVien.Pages
{
    public partial class frmLapPhieuGhiDanh : Form
    {
        private Thread thHocVien;
        private string maPhieu;
        private string maHV;
        private string maKH;
        private bool isSave = false;

        public frmLapPhieuGhiDanh()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load các phiếu ghi danh
        /// </summary>
        public void LoadPhieuGhiDanh()
        {
            //thPhieuGhiDanh = new Thread(() =>
            //{
            object source = PhieuGhiDanh.SelectAll();

            //gridPhieuGhiDanh.Invoke((MethodInvoker)delegate
            // {
            gridPhieuGhiDanh.DataSource = source;
            //});
            //});
            //thPhieuGhiDanh.Start();
        }

        /// <summary>
        /// Kiểm tra nhập liệu tìm kiếm có hợp lệ
        /// </summary>
        public void ValidateSearch()
        {
            if (rdMaHV.Checked && txtMaHV.Text == string.Empty)
                throw new ArgumentException("Mã học viên không được trống");
            if (rdTenHV.Checked && txtTenHV.Text == string.Empty)
                throw new ArgumentException("Họ và tên học viên không được trống");
        }

        /// <summary>
        /// Kiểm tra phiếu ghi danh có hợp lệ
        /// </summary>
        public void ValidatePhieu()
        {
            var f = DangKy.SelectAll(gridDSHV.SelectedRows[0].Cells["clmMaHV"].Value.ToString());

            foreach (var i in f)
                if (i.PHIEUGHIDANH.ConNo > 0)
                    throw new Exception("Học viên đang nợ không được phép ghi danh mới");
            if (numDaDong.Value < GlobalSettings.QuyDinh["QD0001"])
                throw new Exception(string.Format("Số tiền đóng khi ghi danh phải ít nhất bằng {0:C0}", GlobalSettings.QuyDinh["QD0001"]));
        }

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalPages.LapPhieuGhiDanh = null;
        }

        private void rdMaHV_CheckedChanged(object sender, EventArgs e)
        {
            txtMaHV.Enabled = rdMaHV.Checked;
        }

        private void rdTenHV_CheckedChanged(object sender, EventArgs e)
        {
            txtTenHV.Enabled = rdTenHV.Checked;
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            txtMaHV.Text = txtTenHV.Text = string.Empty;
            rdMaHV.Checked = true;
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            gridDSHV.AutoGenerateColumns = false;

            thHocVien = new Thread(() =>
            {
                //thPhieuGhiDanh.Join();

                object source = HocVien.SelectAll();

                gridDSHV.Invoke((MethodInvoker)delegate
                {
                    gridDSHV.DataSource = source;
                });
            });
            thHocVien.Start();
        }

        private void gridDSHV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCongHV.Text = string.Format("Tổng cộng: {0} kết quả", gridDSHV.Rows.Count);
        }

        private void gridDSHV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCongHV.Text = string.Format("Tổng cộng: {0} kết quả", gridDSHV.Rows.Count);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSearch();

                if (rdMaHV.Checked)
                    gridDSHV.DataSource = HocVien.SelectAll(txtMaHV.Text, null, null, null, null, null);
                else if (rdTenHV.Checked)
                    gridDSHV.DataSource = HocVien.SelectAll(null, txtTenHV.Text, null, null, null, null);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmLapPhieuGhiDanh_Load(object sender, EventArgs e)
        {
            //load khóa học
            cboKhoaHoc.DataSource = KhoaHoc.SelectAll();
            cboKhoaHoc.DisplayMember = "TenKH";

            //tạo mã phiếu
            txtMaPhieu.Text = PhieuGhiDanh.AutoGenerateId();

            //load danh sách phiếu
            LoadPhieuGhiDanh();

            //load danh sách học viên
            btnHienTatCa_Click(sender, e);
        }


        private void gridPhieuGhiDanh_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCongPhieu.Text = string.Format("Tổng cộng: {0} phiếu ghi danh", gridPhieuGhiDanh.Rows.Count);
        }

        private void gridPhieuGhiDanh_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCongPhieu.Text = string.Format("Tổng cộng: {0} phiếu ghi danh", gridPhieuGhiDanh.Rows.Count);
        }

        private void cboKhoaHoc_SelectedValueChanged(object sender, EventArgs e)
        {
            numHocPhi.Value = (decimal)((KHOAHOC)cboKhoaHoc.SelectedValue).HocPhi;
            numDaDong.Maximum = numHocPhi.Value;
            numConNo.Value = numHocPhi.Value - numDaDong.Value;
        }

        private void numDaDong_ValueChanged(object sender, EventArgs e)
        {
            numConNo.Value = numHocPhi.Value - numDaDong.Value;
        }

        private void btnDatLaiPhieu_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Text = PhieuGhiDanh.AutoGenerateId();
            numDaDong.Value = 0;
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                ValidatePhieu();

                maPhieu = txtMaPhieu.Text;
                maHV = gridDSHV.SelectedRows[0].Cells["clmMaHV"].Value.ToString();
                maKH = ((KHOAHOC)cboKhoaHoc.SelectedValue).MaKH;
                PhieuGhiDanh.Insert(new PHIEUGHIDANH()
                {
                    MaPhieu = maPhieu,
                    NgayGhiDanh = dateNgayGhiDanh.Value,
                    DaDong = numDaDong.Value,
                    ConNo = numConNo.Value,
                    MaNV = GlobalSettings.UserID,

                    DANGKies = new DANGKY()
                    {
                        MaHV = maHV,
                        MaKH = maKH,
                        MaPhieu = maPhieu
                    }
                });

                MessageBox.Show(string.Format("Phiếu ghi danh {0} đã được thêm thành công", maPhieu), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var h = HocVien.Select(maHV);
                if (h.MaLoaiHV == "LHV00")
                {
                    HocVien.Update(new HOCVIEN()
                    {
                        MaHV = h.MaHV,
                        TenHV = h.TenHV,
                        GioiTinhHV = h.GioiTinhHV,
                        NgaySinh = h.NgaySinh,
                        DiaChi = h.DiaChi,
                        SdtHV = h.SdtHV,
                        EmailHV = h.EmailHV,
                        NgayTiepNhan = h.NgayTiepNhan,
                        MaLoaiHV = "LHV01",
                        TenDangNhap = h.MaHV,
                    },
                    new TAIKHOAN()
                    {
                        TenDangNhap = h.MaHV,
                        MatKhau = h.MaHV
                    });
                    MessageBox.Show(string.Format("Học viên {0} đã được chuyển thành học viên chính thức với tài khoản:{1}Tên đăng nhập: {2}{3}Mật khẩu: {4}",
                        h.TenHV, Environment.NewLine, h.MaHV, Environment.NewLine, h.MaHV),
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                isSave = true;
                LoadPhieuGhiDanh();
                if (MessageBox.Show("Bạn có muốn in phiếu ghi danh vừa lưu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    btnInBienLai_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInBienLai_Click(object sender, EventArgs e)
        {
            if (isSave)
            {
                frmReport frm = new frmReport();

                DANGKY d = DangKy.Select(maHV, maKH, maPhieu);

                List<ReportParameter> _params = new List<ReportParameter>()
                {
                    new ReportParameter("CenterName", GlobalSettings.CenterName),
                    new ReportParameter("CenterWebsite", GlobalSettings.CenterWebsite),
                    new ReportParameter("MaHV", maHV),
                    new ReportParameter("TenHV", d.HOCVIEN.TenHV),
                    new ReportParameter("TenKH", d.KHOAHOC.TenKH),
                    new ReportParameter("HocPhi",((decimal)d.KHOAHOC.HocPhi).ToString("C0")),
                    new ReportParameter("DaDong", ((decimal)d.PHIEUGHIDANH.DaDong).ToString("C0")),
                    new ReportParameter("ConNo", ((decimal)d.PHIEUGHIDANH.ConNo).ToString("C0")),
                };

                frm.ReportViewer.LocalReport.ReportEmbeddedResource = "QuanLyHocVien.Reports.rptBienLaiHocPhi.rdlc";

                frm.ReportViewer.LocalReport.SetParameters(_params);
                frm.ReportViewer.LocalReport.DisplayName = "Biên lai học phí";
                frm.Text = "Biên lai học phí";

                frm.ShowDialog();
            }
            else
                MessageBox.Show("Vui lòng lưu phiếu trước khi in", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridDSHV_Click(object sender, EventArgs e)
        {
            isSave = false;
            btnDatLaiPhieu_Click(sender, e);
        }
        #endregion
    }
}
