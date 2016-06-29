// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmBaoCaoHocVienTheoThang.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Windows.Forms;
using BusinessLogic;
using System.Threading;

namespace QuanLyHocVien.Pages
{
    public partial class frmBaoCaoHocVienTheoThang : Form
    {
        private PhieuGhiDanh busPhieuGhiDanh = new PhieuGhiDanh();

        public frmBaoCaoHocVienTheoThang()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalPages.BaoCaoHocVienTheoThang = null;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                object dshv = busPhieuGhiDanh.BaoCaoHocVienGhiDanhTheoThang(dateThang.Value.Month, dateThang.Value.Year);

                gridBaoCao.Invoke((MethodInvoker)delegate
                {
                    gridBaoCao.DataSource = dshv;
                });
            });

            th.Start();

        }

        private void gridBaoCao_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} học viên", gridBaoCao.Rows.Count);
        }

        private void gridBaoCao_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTongCong.Text = string.Format("Tổng cộng: {0} học viên", gridBaoCao.Rows.Count);
        }
    }
}
