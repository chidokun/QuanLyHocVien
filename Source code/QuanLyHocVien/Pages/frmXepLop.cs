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
        private List<HOCVIEN> dsChuaCoLop;
        private Thread thChuaCoLop;


        public frmXepLop()
        {
            InitializeComponent();
        }

        public void LoadDSHVChuaCoLop()
        {
            gridDSHV.Rows.Clear();

            //thChuaCoLop = new Thread(() =>
            //{
                dsChuaCoLop = HocVien.DanhSachChuaCoLop();

               // gridDSHV.Invoke((MethodInvoker)delegate
                //{
                    foreach (var i in dsChuaCoLop)
                    {
                        string[] s = { i.MaHV, i.TenHV, i.DANGKies.KHOAHOC.TenKH };
                        gridDSHV.Rows.Add(s);
                    }
                //});
            //});

            //thChuaCoLop.Start();   
        }

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
            cboLop.DisplayMember = "MaLop";
            cboLop.ValueMember = "MaLop";

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
            HOCVIEN hv = HocVien.Select(gridDSHV.SelectedRows[0].Cells["clmMaHV"].Value.ToString());

            dsChuaCoLop.Remove(hv);


            string[] s = { hv.MaHV, hv.TenHV, ((DateTime)hv.NgaySinh).ToString("dd/MM/yyyy"), hv.GioiTinhHV, hv.SdtHV, hv.DiaChi, hv.EmailHV };
            gridDSHVLop.Rows.Add(s);
        }

        private void cboLop_SelectedValueChanged(object sender, EventArgs e)
        {
            //load lớp trống của khóa
            cboLop.DataSource = LopHoc.DanhSachLopTrong(cboKhoa.SelectedValue.ToString());
            cboLop.DisplayMember = "MaLop";
            cboLop.ValueMember = "MaLop";
        }
    }
}
