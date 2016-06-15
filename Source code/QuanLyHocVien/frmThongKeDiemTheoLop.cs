// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmThongKeDiemTheoLop.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;

namespace QuanLyHocVien
{
    public partial class frmThongKeDiemTheoLop : Form
    {
        private LopHoc busLopHoc = new LopHoc();
        private BangDiem busBangDiem = new BangDiem();

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            gridLop.DataSource = busLopHoc.Select(txtMaLop.Text);
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            txtMaLop.Text = string.Empty;
        }

        private void btnHienTatCa_Click(object sender, EventArgs e)
        {
            gridLop.DataSource = busLopHoc.SelectAll();
        }

        private void gridLop_Click(object sender, EventArgs e)
        {
            try
            {
                gridThongKe.DataSource = busBangDiem.SelectBangDiemLop(gridLop.SelectedRows[0].Cells["clmMaLop"].Value.ToString());
            }
            catch { }
        }

        private void gridThongKe_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} học viên. Điểm trung bình của lớp: {1} điểm.", gridThongKe.Rows.Count, DiemTrungBinhLop());
        }
    }
}
