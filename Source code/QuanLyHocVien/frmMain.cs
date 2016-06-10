using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyHocVien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region Ribbon bar
        private void ResetColorTabTitle()
        {
            btnNhanVienTitle.BackColor = Color.White;
            btnGiangVienTitle.BackColor = Color.White;
            btnHocVienTitle.BackColor = Color.White;
            btnQuanTriTitle.BackColor = Color.White;
            btnTroGiupTitle.BackColor = Color.White;
        }

        private void btnNhanVienTitle_Click(object sender, EventArgs e)
        {
            tabRibbon.SelectedTab = tabRibbon.TabPages["tabNhanVien"];

            ResetColorTabTitle();
            ((Button)sender).BackColor = Color.FromArgb(233, 233, 233);
        }

        private void btnGiangVienTitle_Click(object sender, EventArgs e)
        {
            tabRibbon.SelectedTab = tabRibbon.TabPages["tabGiangVien"];

            ResetColorTabTitle();
            ((Button)sender).BackColor = Color.FromArgb(233, 233, 233);
        }

        private void btnHocVienTitle_Click(object sender, EventArgs e)
        {
            tabRibbon.SelectedTab = tabRibbon.TabPages["tabHocVien"];

            ResetColorTabTitle();
            ((Button)sender).BackColor = Color.FromArgb(233, 233, 233);
        }

        private void btnQuanTriTitle_Click(object sender, EventArgs e)
        {
            tabRibbon.SelectedTab = tabRibbon.TabPages["tabQuanTri"];

            ResetColorTabTitle();
            ((Button)sender).BackColor = Color.FromArgb(233, 233, 233);
        }

        private void btnTroGiupTitle_Click(object sender, EventArgs e)
        {
            tabRibbon.SelectedTab = tabRibbon.TabPages["tabTroGiup"];

            ResetColorTabTitle();
            ((Button)sender).BackColor = Color.FromArgb(233, 233, 233);
        }


        #endregion

        private void btnThongTinTrungTam_Click(object sender, EventArgs e)
        {
            frmThongTinTrungTam frm = new frmThongTinTrungTam();
            frm.ShowDialog();
        }

        private void btnThongTinPhanMem_Click(object sender, EventArgs e)
        {
            frmThongTinPhanMem frm = new frmThongTinPhanMem();
            frm.ShowDialog();
        }

        private void btnCaiDatVaQuyDinh_Click(object sender, EventArgs e)
        {
            frmCaiDatVaQuyDinh frm = new frmCaiDatVaQuyDinh();
            frm.ShowDialog();
        }

        private void btnTiepNhanHocVien_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmTiepNhanHocVien frm = new frmTiepNhanHocVien();
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }

        private void btnLapPhieuGhiDanh_Click(object sender, EventArgs e)
        {
            pnlWorkspace.Controls.Clear();

            frmLapPhieuGhiDanh frm = new frmLapPhieuGhiDanh();
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            pnlWorkspace.Controls.Add(frm);
            frm.Show();
        }
    }
}
