// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmThongKeDiemTheoLop.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;
using System.Threading;
using QuanLyHocVien.Reports;
using Microsoft.Reporting.WinForms;
using System.Data;
using System.Collections.Generic;

namespace QuanLyHocVien.Pages
{
    public partial class frmThongKeDiemTheoLop : Form
    {
        private Thread thLop;
        private Thread thBangDiem;

        public frmThongKeDiemTheoLop()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tính điểm trung bình lớp
        /// </summary>
        /// <returns></returns>
        public double DiemTrungBinhLop()
        {
            double diem = 0;
            for (int i = 0; i < gridThongKe.Rows.Count; i++)
                diem += Convert.ToDouble(gridThongKe.Rows[i].Cells["clmDiemTrungBinh"].Value);

            return diem / gridThongKe.Rows.Count;
        }

        /// <summary>
        /// Kiểm tra nhập liệu tìm kiếm có hợp lệ
        /// </summary>
        public void ValidateSearch()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
                throw new ArgumentException("Mã lớp không được trống");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalPages.ThongKeDiemTheoLop = null;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSearch();

                thLop = new Thread(() =>
                {
                    object source = LopHoc.Select(txtMaLop.Text);

                    gridLop.Invoke((MethodInvoker)delegate
                    {
                        gridLop.DataSource = source;
                    });
                });

                thLop.Start();
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

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            txtMaLop.Text = string.Empty;
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            thLop = new Thread(() =>
            {
                object source = LopHoc.SelectAll();

                gridLop.Invoke((MethodInvoker)delegate
                {
                    gridLop.DataSource = source;
                });
            });

            thLop.Start();
        }

        private void gridLop_Click(object sender, EventArgs e)
        {
            try
            {
                thBangDiem = new Thread(() =>
                {
                    thLop.Join();

                    object source = BangDiem.SelectBangDiemLop(gridLop.SelectedRows[0].Cells["clmMaLop"].Value.ToString());

                    gridThongKe.Invoke((MethodInvoker)delegate
                    {
                        gridThongKe.DataSource = source;
                    });
                });

                thBangDiem.Start();
            }
            catch { }
        }

        private void gridThongKe_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} học viên. Điểm trung bình của lớp: {1:N2} điểm.", gridThongKe.Rows.Count, DiemTrungBinhLop());
        }

        private void frmThongKeDiemTheoLop_Load(object sender, EventArgs e)
        {
            gridLop.AutoGenerateColumns = false;

            btnHienTatCa_Click(sender, e);
            gridLop_Click(sender, e);
        }

        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport();

            List<ReportParameter> _params = new List<ReportParameter>()
            {
                new ReportParameter("CenterName", GlobalSettings.CenterName),
                new ReportParameter("CenterWebsite", GlobalSettings.CenterWebsite),
                new ReportParameter("MaLop", gridLop.SelectedRows[0].Cells["clmMaLop"].Value.ToString()),
                new ReportParameter("TenLop", gridLop.SelectedRows[0].Cells["clmTenLop"].Value.ToString()),
                new ReportParameter("DiemTBLop", string.Format("{0:N2}",DiemTrungBinhLop()))
            };

            frm.ReportViewer.LocalReport.ReportEmbeddedResource = "QuanLyHocVien.Reports.rptBangDiemLop.rdlc";

            dsSource.dtBangDiemLopDataTable dt = new dsSource.dtBangDiemLopDataTable();
            var query = BangDiem.SelectBangDiemLop(gridLop.SelectedRows[0].Cells["clmMaLop"].Value.ToString());
            foreach (var i in query)
            {
                dt.Rows.Add(i.MaHV, i.TenHV, i.DiemNghe, i.DiemNoi, i.DiemDoc, i.DiemViet, i.DiemTrungBinh);
            }

            frm.ReportViewer.LocalReport.DataSources.Clear();
            frm.ReportViewer.LocalReport.DataSources.Add(new ReportDataSource("ds", (DataTable)dt));

            frm.ReportViewer.LocalReport.SetParameters(_params);
            frm.ReportViewer.LocalReport.DisplayName = "Bảng điểm lớp";
            frm.Text = "Thống kê điểm theo lớp";

            frm.ShowDialog();
        }
    }
}
