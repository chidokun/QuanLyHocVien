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
    public partial class frmQuanLyHocVien : Form
    {
        public frmQuanLyHocVien()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmHocVienEdit frm = new frmHocVienEdit();
            frm.Show();
        }
    }
}
