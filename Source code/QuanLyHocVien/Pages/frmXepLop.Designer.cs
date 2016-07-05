namespace QuanLyHocVien.Pages
{
    partial class frmXepLop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnThemVaoLop = new System.Windows.Forms.Button();
            this.lblTongCongHV = new System.Windows.Forms.Label();
            this.gridDSHV = new System.Windows.Forms.DataGridView();
            this.clmMaHV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenHV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMaPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmKhoaHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBoKhoiLop = new System.Windows.Forms.Button();
            this.btnDatLai = new System.Windows.Forms.Button();
            this.btnLuuLop = new System.Windows.Forms.Button();
            this.lblTongCongHVLop = new System.Windows.Forms.Label();
            this.gridDSHVLop = new System.Windows.Forms.DataGridView();
            this.clmMaHVLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSdtHV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMaPhieuLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSHV)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSHVLop)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1114, 24);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "XẾP LỚP";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.LightGray;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::QuanLyHocVien.Properties.Resources.icon_Close_9dp;
            this.btnClose.Location = new System.Drawing.Point(1074, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(28, 19);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.btnThemVaoLop);
            this.splitContainer1.Panel1.Controls.Add(this.lblTongCongHV);
            this.splitContainer1.Panel1.Controls.Add(this.gridDSHV);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1114, 466);
            this.splitContainer1.SplitterDistance = 417;
            this.splitContainer1.TabIndex = 4;
            // 
            // btnThemVaoLop
            // 
            this.btnThemVaoLop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemVaoLop.BackColor = System.Drawing.Color.Silver;
            this.btnThemVaoLop.FlatAppearance.BorderSize = 0;
            this.btnThemVaoLop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnThemVaoLop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnThemVaoLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemVaoLop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThemVaoLop.Image = global::QuanLyHocVien.Properties.Resources.add_16x16;
            this.btnThemVaoLop.Location = new System.Drawing.Point(269, 396);
            this.btnThemVaoLop.Name = "btnThemVaoLop";
            this.btnThemVaoLop.Size = new System.Drawing.Size(128, 34);
            this.btnThemVaoLop.TabIndex = 30;
            this.btnThemVaoLop.Text = "Thêm vào lớp";
            this.btnThemVaoLop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThemVaoLop.UseVisualStyleBackColor = false;
            this.btnThemVaoLop.Click += new System.EventHandler(this.btnThemVaoLop_Click);
            // 
            // lblTongCongHV
            // 
            this.lblTongCongHV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongCongHV.AutoSize = true;
            this.lblTongCongHV.Location = new System.Drawing.Point(18, 442);
            this.lblTongCongHV.Name = "lblTongCongHV";
            this.lblTongCongHV.Size = new System.Drawing.Size(125, 15);
            this.lblTongCongHV.TabIndex = 14;
            this.lblTongCongHV.Text = "Tổng cộng: 0 học viên";
            // 
            // gridDSHV
            // 
            this.gridDSHV.AllowUserToAddRows = false;
            this.gridDSHV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDSHV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDSHV.BackgroundColor = System.Drawing.Color.White;
            this.gridDSHV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridDSHV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDSHV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMaHV,
            this.clmTenHV,
            this.clmMaPhieu,
            this.clmKhoaHoc});
            this.gridDSHV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridDSHV.Location = new System.Drawing.Point(21, 45);
            this.gridDSHV.MultiSelect = false;
            this.gridDSHV.Name = "gridDSHV";
            this.gridDSHV.RowHeadersVisible = false;
            this.gridDSHV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDSHV.Size = new System.Drawing.Size(376, 345);
            this.gridDSHV.TabIndex = 13;
            this.gridDSHV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridDSHV_RowsAdded);
            this.gridDSHV.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gridDSHV_RowsRemoved);
            // 
            // clmMaHV
            // 
            this.clmMaHV.DataPropertyName = "MaHV";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.clmMaHV.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmMaHV.HeaderText = "Mã học viên";
            this.clmMaHV.Name = "clmMaHV";
            // 
            // clmTenHV
            // 
            this.clmTenHV.DataPropertyName = "TenHV";
            this.clmTenHV.HeaderText = "Họ và tên";
            this.clmTenHV.Name = "clmTenHV";
            // 
            // clmMaPhieu
            // 
            this.clmMaPhieu.DataPropertyName = "MaPhieu";
            this.clmMaPhieu.HeaderText = "Mã phiếu";
            this.clmMaPhieu.Name = "clmMaPhieu";
            // 
            // clmKhoaHoc
            // 
            this.clmKhoaHoc.DataPropertyName = "TenKH";
            this.clmKhoaHoc.HeaderText = "Khóa học";
            this.clmKhoaHoc.Name = "clmKhoaHoc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Danh sách các học viên chưa có lớp";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnBoKhoiLop);
            this.panel2.Controls.Add(this.btnDatLai);
            this.panel2.Controls.Add(this.btnLuuLop);
            this.panel2.Controls.Add(this.lblTongCongHVLop);
            this.panel2.Controls.Add(this.gridDSHVLop);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cboLop);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cboKhoa);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(693, 466);
            this.panel2.TabIndex = 0;
            // 
            // btnBoKhoiLop
            // 
            this.btnBoKhoiLop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBoKhoiLop.BackColor = System.Drawing.Color.Silver;
            this.btnBoKhoiLop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBoKhoiLop.FlatAppearance.BorderSize = 0;
            this.btnBoKhoiLop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnBoKhoiLop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBoKhoiLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoKhoiLop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBoKhoiLop.Image = global::QuanLyHocVien.Properties.Resources.remove_16x16;
            this.btnBoKhoiLop.Location = new System.Drawing.Point(18, 396);
            this.btnBoKhoiLop.Name = "btnBoKhoiLop";
            this.btnBoKhoiLop.Size = new System.Drawing.Size(117, 34);
            this.btnBoKhoiLop.TabIndex = 72;
            this.btnBoKhoiLop.Text = "Bỏ khỏi lớp";
            this.btnBoKhoiLop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBoKhoiLop.UseVisualStyleBackColor = false;
            this.btnBoKhoiLop.Click += new System.EventHandler(this.btnBoKhoiLop_Click);
            // 
            // btnDatLai
            // 
            this.btnDatLai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDatLai.BackColor = System.Drawing.Color.Silver;
            this.btnDatLai.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDatLai.FlatAppearance.BorderSize = 0;
            this.btnDatLai.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnDatLai.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDatLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatLai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDatLai.Image = global::QuanLyHocVien.Properties.Resources.refresh2_16x16;
            this.btnDatLai.Location = new System.Drawing.Point(584, 396);
            this.btnDatLai.Name = "btnDatLai";
            this.btnDatLai.Size = new System.Drawing.Size(83, 34);
            this.btnDatLai.TabIndex = 71;
            this.btnDatLai.Text = "Đặt lại";
            this.btnDatLai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDatLai.UseVisualStyleBackColor = false;
            this.btnDatLai.Click += new System.EventHandler(this.btnDatLai_Click);
            // 
            // btnLuuLop
            // 
            this.btnLuuLop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuLop.BackColor = System.Drawing.Color.Silver;
            this.btnLuuLop.FlatAppearance.BorderSize = 0;
            this.btnLuuLop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnLuuLop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLuuLop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuLop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuuLop.Image = global::QuanLyHocVien.Properties.Resources.save_16x16;
            this.btnLuuLop.Location = new System.Drawing.Point(482, 396);
            this.btnLuuLop.Name = "btnLuuLop";
            this.btnLuuLop.Size = new System.Drawing.Size(96, 34);
            this.btnLuuLop.TabIndex = 70;
            this.btnLuuLop.Text = "Lưu lớp";
            this.btnLuuLop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuuLop.UseVisualStyleBackColor = false;
            this.btnLuuLop.Click += new System.EventHandler(this.btnLuuLop_Click);
            // 
            // lblTongCongHVLop
            // 
            this.lblTongCongHVLop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongCongHVLop.AutoSize = true;
            this.lblTongCongHVLop.Location = new System.Drawing.Point(15, 442);
            this.lblTongCongHVLop.Name = "lblTongCongHVLop";
            this.lblTongCongHVLop.Size = new System.Drawing.Size(125, 15);
            this.lblTongCongHVLop.TabIndex = 15;
            this.lblTongCongHVLop.Text = "Tổng cộng: 0 học viên";
            // 
            // gridDSHVLop
            // 
            this.gridDSHVLop.AllowUserToAddRows = false;
            this.gridDSHVLop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDSHVLop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDSHVLop.BackgroundColor = System.Drawing.Color.White;
            this.gridDSHVLop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridDSHVLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDSHVLop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMaHVLop,
            this.dataGridViewTextBoxColumn2,
            this.clmNgaySinh,
            this.clmGioiTinh,
            this.clmSdtHV,
            this.clmDiaChi,
            this.clmMaPhieuLop});
            this.gridDSHVLop.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridDSHVLop.Location = new System.Drawing.Point(16, 63);
            this.gridDSHVLop.MultiSelect = false;
            this.gridDSHVLop.Name = "gridDSHVLop";
            this.gridDSHVLop.ReadOnly = true;
            this.gridDSHVLop.RowHeadersVisible = false;
            this.gridDSHVLop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDSHVLop.Size = new System.Drawing.Size(651, 327);
            this.gridDSHVLop.TabIndex = 69;
            this.gridDSHVLop.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gridDSHVLop_RowsAdded);
            this.gridDSHVLop.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.gridDSHVLop_RowsRemoved);
            // 
            // clmMaHVLop
            // 
            this.clmMaHVLop.DataPropertyName = "MaHV";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            this.clmMaHVLop.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmMaHVLop.HeaderText = "Mã học viên";
            this.clmMaHVLop.Name = "clmMaHVLop";
            this.clmMaHVLop.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TenHV";
            this.dataGridViewTextBoxColumn2.HeaderText = "Họ và tên";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // clmNgaySinh
            // 
            this.clmNgaySinh.DataPropertyName = "NgaySinh";
            this.clmNgaySinh.HeaderText = "Ngày sinh";
            this.clmNgaySinh.Name = "clmNgaySinh";
            this.clmNgaySinh.ReadOnly = true;
            // 
            // clmGioiTinh
            // 
            this.clmGioiTinh.DataPropertyName = "GioiTinhHV";
            this.clmGioiTinh.HeaderText = "Giới tính";
            this.clmGioiTinh.Name = "clmGioiTinh";
            this.clmGioiTinh.ReadOnly = true;
            // 
            // clmSdtHV
            // 
            this.clmSdtHV.DataPropertyName = "SdtHV";
            this.clmSdtHV.HeaderText = "SĐT";
            this.clmSdtHV.Name = "clmSdtHV";
            this.clmSdtHV.ReadOnly = true;
            // 
            // clmDiaChi
            // 
            this.clmDiaChi.DataPropertyName = "DiaChi";
            this.clmDiaChi.HeaderText = "Địa chỉ";
            this.clmDiaChi.Name = "clmDiaChi";
            this.clmDiaChi.ReadOnly = true;
            // 
            // clmMaPhieuLop
            // 
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            this.clmMaPhieuLop.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmMaPhieuLop.HeaderText = "Mã phiếu";
            this.clmMaPhieuLop.Name = "clmMaPhieuLop";
            this.clmMaPhieuLop.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 15);
            this.label5.TabIndex = 68;
            this.label5.Text = "Danh sách học viên trong lớp";
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(411, 11);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(215, 25);
            this.cboLop.TabIndex = 67;
            this.cboLop.SelectedValueChanged += new System.EventHandler(this.cboLop_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 15);
            this.label4.TabIndex = 66;
            this.label4.Text = "Danh sách lớp trống:";
            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(87, 11);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(188, 25);
            this.cboKhoa.TabIndex = 65;
            this.cboKhoa.SelectedValueChanged += new System.EventHandler(this.cboKhoa_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Chọn khóa:";
            // 
            // frmXepLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1114, 490);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(48)))), ((int)(((byte)(70)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmXepLop";
            this.Text = "Xếp lớp";
            this.Load += new System.EventHandler(this.frmXepLop_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDSHV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSHVLop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridDSHV;
        private System.Windows.Forms.Label lblTongCongHV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Label lblTongCongHVLop;
        private System.Windows.Forms.DataGridView gridDSHVLop;
        private System.Windows.Forms.Button btnThemVaoLop;
        private System.Windows.Forms.Button btnLuuLop;
        private System.Windows.Forms.Button btnBoKhoiLop;
        private System.Windows.Forms.Button btnDatLai;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaHV;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenHV;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmKhoaHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaHVLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSdtHV;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaPhieuLop;
    }
}