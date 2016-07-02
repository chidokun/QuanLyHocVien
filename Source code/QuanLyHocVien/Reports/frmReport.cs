// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmInBangDiem.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace QuanLyHocVien.Reports
{
    public partial class frmReport : Form
    {
        public ReportViewer ReportViewer
        {
            get { return this.reportViewer1; }
        }

        public frmReport()
        {
            InitializeComponent();
        }

        private void frmInBangDiem_Load(object sender, EventArgs e)
        {
            ReportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            ReportViewer.ZoomMode = ZoomMode.Percent;
            ReportViewer.ZoomPercent = 100;
            this.reportViewer1.RefreshReport();
        }
    }
}
