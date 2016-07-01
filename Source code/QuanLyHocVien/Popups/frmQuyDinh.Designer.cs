namespace QuanLyHocVien.Popups
{
    partial class frmQuyDinh
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDat = new System.Windows.Forms.Button();
            this.lblTenQD = new System.Windows.Forms.Label();
            this.numGiaTri = new System.Windows.Forms.NumericUpDown();
            this.gridQD = new System.Windows.Forms.DataGridView();
            this.clmMaQD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTenQD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGiaTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.btnLuuQuyDinh = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaTri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQD)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(626, 305);
            this.panel2.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnDat);
            this.groupBox2.Controls.Add(this.lblTenQD);
            this.groupBox2.Controls.Add(this.numGiaTri);
            this.groupBox2.Controls.Add(this.gridQD);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(26, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(573, 258);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quy định";
            // 
            // btnDat
            // 
            this.btnDat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDat.BackColor = System.Drawing.Color.Silver;
            this.btnDat.FlatAppearance.BorderSize = 0;
            this.btnDat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnDat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDat.Location = new System.Drawing.Point(498, 24);
            this.btnDat.Name = "btnDat";
            this.btnDat.Size = new System.Drawing.Size(57, 26);
            this.btnDat.TabIndex = 3;
            this.btnDat.Text = "Đặt";
            this.btnDat.UseVisualStyleBackColor = false;
            this.btnDat.Click += new System.EventHandler(this.btnDat_Click);
            // 
            // lblTenQD
            // 
            this.lblTenQD.AutoSize = true;
            this.lblTenQD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTenQD.ForeColor = System.Drawing.Color.Green;
            this.lblTenQD.Location = new System.Drawing.Point(102, 26);
            this.lblTenQD.Name = "lblTenQD";
            this.lblTenQD.Size = new System.Drawing.Size(74, 19);
            this.lblTenQD.TabIndex = 67;
            this.lblTenQD.Text = "<setting>";
            // 
            // numGiaTri
            // 
            this.numGiaTri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numGiaTri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numGiaTri.Location = new System.Drawing.Point(404, 24);
            this.numGiaTri.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numGiaTri.Name = "numGiaTri";
            this.numGiaTri.Size = new System.Drawing.Size(87, 25);
            this.numGiaTri.TabIndex = 2;
            this.numGiaTri.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gridQD
            // 
            this.gridQD.AllowUserToAddRows = false;
            this.gridQD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridQD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridQD.BackgroundColor = System.Drawing.Color.White;
            this.gridQD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridQD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridQD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMaQD,
            this.clmTenQD,
            this.clmGiaTri});
            this.gridQD.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridQD.Location = new System.Drawing.Point(14, 73);
            this.gridQD.MultiSelect = false;
            this.gridQD.Name = "gridQD";
            this.gridQD.ReadOnly = true;
            this.gridQD.RowHeadersVisible = false;
            this.gridQD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridQD.Size = new System.Drawing.Size(541, 168);
            this.gridQD.StandardTab = true;
            this.gridQD.TabIndex = 1;
            this.gridQD.Click += new System.EventHandler(this.gridQD_Click);
            // 
            // clmMaQD
            // 
            this.clmMaQD.DataPropertyName = "MaQD";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue;
            this.clmMaQD.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmMaQD.FillWeight = 30F;
            this.clmMaQD.HeaderText = "Mã quy định";
            this.clmMaQD.Name = "clmMaQD";
            this.clmMaQD.ReadOnly = true;
            // 
            // clmTenQD
            // 
            this.clmTenQD.DataPropertyName = "TenQD";
            this.clmTenQD.HeaderText = "Tên quy định";
            this.clmTenQD.Name = "clmTenQD";
            this.clmTenQD.ReadOnly = true;
            // 
            // clmGiaTri
            // 
            this.clmGiaTri.DataPropertyName = "GiaTri";
            this.clmGiaTri.FillWeight = 25F;
            this.clmGiaTri.HeaderText = "Giá trị";
            this.clmGiaTri.Name = "clmGiaTri";
            this.clmGiaTri.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 15);
            this.label5.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "Tên quy định:";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(11, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(322, 35);
            this.label2.TabIndex = 24;
            this.label2.Text = "Chọn một quy định trong bảng danh mục để thay đổi.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnHuyBo);
            this.panel1.Controls.Add(this.btnLuuQuyDinh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 305);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 61);
            this.panel1.TabIndex = 2;
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuyBo.BackColor = System.Drawing.Color.Silver;
            this.btnHuyBo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuyBo.FlatAppearance.BorderSize = 0;
            this.btnHuyBo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnHuyBo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHuyBo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyBo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHuyBo.Location = new System.Drawing.Point(509, 12);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(107, 37);
            this.btnHuyBo.TabIndex = 5;
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.UseVisualStyleBackColor = false;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // btnLuuQuyDinh
            // 
            this.btnLuuQuyDinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuQuyDinh.BackColor = System.Drawing.Color.Silver;
            this.btnLuuQuyDinh.FlatAppearance.BorderSize = 0;
            this.btnLuuQuyDinh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnLuuQuyDinh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLuuQuyDinh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuQuyDinh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuuQuyDinh.Location = new System.Drawing.Point(396, 12);
            this.btnLuuQuyDinh.Name = "btnLuuQuyDinh";
            this.btnLuuQuyDinh.Size = new System.Drawing.Size(107, 37);
            this.btnLuuQuyDinh.TabIndex = 4;
            this.btnLuuQuyDinh.Text = "Lưu quy định";
            this.btnLuuQuyDinh.UseVisualStyleBackColor = false;
            this.btnLuuQuyDinh.Click += new System.EventHandler(this.btnLuuQuyDinh_Click);
            // 
            // frmQuyDinh
            // 
            this.AcceptButton = this.btnLuuQuyDinh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnHuyBo;
            this.ClientSize = new System.Drawing.Size(626, 366);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuyDinh";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi quy định";
            this.Load += new System.EventHandler(this.frmQuyDinh_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaTri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHuyBo;
        private System.Windows.Forms.Button btnLuuQuyDinh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTenQD;
        private System.Windows.Forms.NumericUpDown numGiaTri;
        private System.Windows.Forms.DataGridView gridQD;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMaQD;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTenQD;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGiaTri;
        private System.Windows.Forms.Button btnDat;
    }
}