// Quản lý Học viên Trung tâm Anh ngữ
// Copyright © 2016, VP2T
// File "frmQuyDinh.cs"
// Writing by Nguyễn Lê Hoàng Tuấn (nguyentuanit96@gmail.com)

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;

namespace QuanLyHocVien.Popups
{
    public partial class frmQuyDinh : Form
    {
        private QuyDinh busQuyDinh = new QuyDinh();
        private string currentQD;

        public frmQuyDinh()
        {
            InitializeComponent();
        }

        #region Events

        private void frmQuyDinh_Load(object sender, EventArgs e)
        {
            gridQD.AutoGenerateColumns = false;
            List<QUYDINH> source = busQuyDinh.SelectAll();
            foreach (var i in source)
                gridQD.Rows.Add(new string[]
                {
                    i.MaQD,
                    i.TenQD,
                    i.GiaTri.ToString()
                });

            gridQD_Click(sender, e);
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridQD_Click(object sender, EventArgs e)
        {
            var r = gridQD.SelectedRows[0];
            lblTenQD.Text = r.Cells["clmTenQD"].Value.ToString();
            numGiaTri.Value = Convert.ToDecimal(r.Cells["clmGiaTri"].Value);
            currentQD = r.Cells["clmMaQD"].Value.ToString();
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            var r = gridQD.SelectedRows[0];
            r.Cells["clmGiaTri"].Value = numGiaTri.Value;
        }

        private void btnLuuQuyDinh_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = gridQD.Rows;
                foreach (DataGridViewRow i in rows)
                {
                    busQuyDinh.Update(new QUYDINH()
                    {
                        MaQD = i.Cells["clmMaQD"].Value.ToString(),
                        GiaTri = Convert.ToInt16(i.Cells["clmGiaTri"].Value)
                    });
                }
                MessageBox.Show("Lưu các quy định thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
