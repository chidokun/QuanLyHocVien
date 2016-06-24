using QuanLyHocVien.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyHocVien
{
    public static class GlobalPages
    {
        public static frmTiepNhanHocVien TiepNhanHocVien { get; set; } = null;

        public static frmLapPhieuGhiDanh LapPhieuGhiDanh { get; set; } = null;

        public static frmBaoCaoHocVienTheoThang BaoCaoHocVienTheoThang { get; set; } = null;

        public static frmThongKeNoHocVien ThongKeNoHocVien { get; set; } = null;

        public static frmQuanLyDiem QuanLyDiem { get; set; } = null;

        public static frmThongKeDiemTheoLop ThongKeDiemTheoLop { get; set; } = null;

        public static frmXepLop XepLop { get; set; } = null;

        public static frmQuanLyHocVien QuanLyHocVien { get; set; } = null;

        public static frmQuanLyNhanVien QuanLyNhanVien { get; set; } = null;

        public static frmQuanLyGiangVien QuanLyGiangVien { get; set; } = null;

        public static frmQuanLyLopHoc QuanLyLopHoc { get; set; } = null;

        public static frmQuanLyKhoaHoc QuanLyKhoaHoc { get; set; } = null;

        //public static frmQuanLyHocPhi QuanLyHocPhi { get; set; }= null;

        public static frmQuanLyTaiKhoan QuanLyTaiKhoan { get; set; } = null;


        public static void LoadEssentialPages()
        {
            Thread thread = new Thread(() =>
            {
                if (TiepNhanHocVien == null) TiepNhanHocVien = new frmTiepNhanHocVien() { Dock = DockStyle.Fill, TopLevel = false };
                if (LapPhieuGhiDanh == null) LapPhieuGhiDanh = new frmLapPhieuGhiDanh() { Dock = DockStyle.Fill, TopLevel = false };
                if (BaoCaoHocVienTheoThang == null) BaoCaoHocVienTheoThang = new frmBaoCaoHocVienTheoThang() { Dock = DockStyle.Fill, TopLevel = false };
                if (ThongKeNoHocVien == null) ThongKeNoHocVien = new frmThongKeNoHocVien() { Dock = DockStyle.Fill, TopLevel = false };
                if (QuanLyDiem == null) QuanLyDiem = new frmQuanLyDiem() { Dock = DockStyle.Fill, TopLevel = false };
                if (ThongKeDiemTheoLop == null) ThongKeDiemTheoLop = new frmThongKeDiemTheoLop() { Dock = DockStyle.Fill, TopLevel = false };
                if (XepLop == null) XepLop = new frmXepLop() { Dock = DockStyle.Fill, TopLevel = false };
                if (QuanLyHocVien == null) QuanLyHocVien = new frmQuanLyHocVien() { Dock = DockStyle.Fill, TopLevel = false };
                if (QuanLyNhanVien == null) QuanLyNhanVien = new frmQuanLyNhanVien() { Dock = DockStyle.Fill, TopLevel = false };
                if (QuanLyGiangVien == null) QuanLyGiangVien = new frmQuanLyGiangVien() { Dock = DockStyle.Fill, TopLevel = false };
                if (QuanLyLopHoc == null) QuanLyLopHoc = new frmQuanLyLopHoc() { Dock = DockStyle.Fill, TopLevel = false };
                if (QuanLyKhoaHoc == null) QuanLyKhoaHoc = new frmQuanLyKhoaHoc() { Dock = DockStyle.Fill, TopLevel = false };
                //if (QuanLyHocPhi == null) QuanLyHocPhi = new frmQuanLyHocPhi(){ Dock = DockStyle.Fill, TopLevel = false };
                if (QuanLyTaiKhoan == null) QuanLyTaiKhoan = new frmQuanLyTaiKhoan() { Dock = DockStyle.Fill, TopLevel = false };

            });

            thread.Priority = ThreadPriority.Highest;
            thread.Start();
        }

    }
}
