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
    public partial class frmQuanLyGiangVien : Form
    {
        public frmQuanLyGiangVien()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmGiangVienEdit frm = new frmGiangVienEdit();
            frm.ShowDialog();
        }
    }
}
