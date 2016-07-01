// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmThongKeNoHocVien.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;
using System.Threading;

namespace QuanLyHocVien.Pages
{
    public partial class frmThongKeNoHocVien : Form
    { 
        public frmThongKeNoHocVien()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tính tổng nợ
        /// </summary>
        /// <returns></returns>
        public double TongNo()
        {
            double sum = 0;
            for (int i = 0; i < gridBaoCao.Rows.Count; i++)
                sum += Convert.ToDouble(gridBaoCao.Rows[i].Cells["clmConNo"].Value);
            return sum;
        }

        private void frmThongKeNoHocVien_Load(object sender, EventArgs e)
        {
            gridBaoCao.AutoGenerateColumns = false;

            Thread th = new Thread(() =>
            {
                object source = PhieuGhiDanh.ThongKeDanhSachNoHocPhi();

                gridBaoCao.Invoke((MethodInvoker)delegate
                {
                    gridBaoCao.DataSource = source;
                });
            });

            th.Start();           
        }

        private void gridBaoCao_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} học viên còn nợ. Tổng nợ: {1} VNĐ",gridBaoCao.Rows.Count,TongNo());
        }

        private void gridBaoCao_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} học viên còn nợ. Tổng nợ: {1} VNĐ", gridBaoCao.Rows.Count, TongNo());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalPages.ThongKeNoHocVien = null;
        }
    }
}
