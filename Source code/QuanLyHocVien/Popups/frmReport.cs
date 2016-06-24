using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyHocVien.Popups
{
    public partial class frmReport : Form
    {
        /// <summary>
        /// Nguồn file report có sẵn
        /// </summary>
        public string ReportResource
        {
            get { return reportViewer.LocalReport.ReportEmbeddedResource; }
            set { reportViewer.LocalReport.ReportEmbeddedResource = value; }
        }

        /// <summary>
        /// Nguồn dữ liệu cho report
        /// </summary>
        public ReportDataSourceCollection DataSource
        {
            get { return reportViewer.LocalReport.DataSources; }
        }

        /// <summary>
        /// Danh sách tham số
        /// </summary>
        public List<ReportParameter> Parameters
        {
            set
            {
                reportViewer.LocalReport.SetParameters(value);
            }
        }

        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {

            this.reportViewer.RefreshReport();
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
        }
    }
}
