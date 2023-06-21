namespace COOPFOOD
{
    partial class frmNhanVien
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
            this.label4 = new System.Windows.Forms.Label();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.grp_NhanVien = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dtNSinh = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtHo = new System.Windows.Forms.TextBox();
            this.txtPhai = new System.Windows.Forms.TextBox();
            this.txtMa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.grp_NhanVien.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(268, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 42);
            this.label4.TabIndex = 1;
            this.label4.Text = "NHÂN VIÊN";
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvNhanVien.Location = new System.Drawing.Point(0, 292);
            this.dgvNhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.RowTemplate.Height = 28;
            this.dgvNhanVien.Size = new System.Drawing.Size(813, 229);
            this.dgvNhanVien.TabIndex = 5;
            this.dgvNhanVien.TabStop = false;
            this.dgvNhanVien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellContentClick);
            // 
            // grp_NhanVien
            // 
            this.grp_NhanVien.Controls.Add(this.btnThoat);
            this.grp_NhanVien.Controls.Add(this.btnReset);
            this.grp_NhanVien.Controls.Add(this.btnXoa);
            this.grp_NhanVien.Controls.Add(this.btnSua);
            this.grp_NhanVien.Controls.Add(this.btnThem);
            this.grp_NhanVien.Controls.Add(this.dtNSinh);
            this.grp_NhanVien.Controls.Add(this.label9);
            this.grp_NhanVien.Controls.Add(this.label8);
            this.grp_NhanVien.Controls.Add(this.label5);
            this.grp_NhanVien.Controls.Add(this.label3);
            this.grp_NhanVien.Controls.Add(this.label7);
            this.grp_NhanVien.Controls.Add(this.label2);
            this.grp_NhanVien.Controls.Add(this.label6);
            this.grp_NhanVien.Controls.Add(this.label1);
            this.grp_NhanVien.Controls.Add(this.txtCMND);
            this.grp_NhanVien.Controls.Add(this.txtSDT);
            this.grp_NhanVien.Controls.Add(this.txtTen);
            this.grp_NhanVien.Controls.Add(this.txtDiaChi);
            this.grp_NhanVien.Controls.Add(this.txtHo);
            this.grp_NhanVien.Controls.Add(this.txtPhai);
            this.grp_NhanVien.Controls.Add(this.txtMa);
            this.grp_NhanVien.Location = new System.Drawing.Point(0, 52);
            this.grp_NhanVien.Name = "grp_NhanVien";
            this.grp_NhanVien.Size = new System.Drawing.Size(812, 235);
            this.grp_NhanVien.TabIndex = 6;
            this.grp_NhanVien.TabStop = false;
            this.grp_NhanVien.Text = "Thông tin nhân viên";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(631, 174);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(125, 43);
            this.btnThoat.TabIndex = 34;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Lime;
            this.btnReset.Location = new System.Drawing.Point(482, 174);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(125, 43);
            this.btnReset.TabIndex = 33;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Red;
            this.btnXoa.Location = new System.Drawing.Point(336, 174);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(125, 43);
            this.btnXoa.TabIndex = 32;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSua.Location = new System.Drawing.Point(191, 174);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(125, 43);
            this.btnSua.TabIndex = 31;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Aqua;
            this.btnThem.Location = new System.Drawing.Point(49, 174);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(124, 43);
            this.btnThem.TabIndex = 30;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dtNSinh
            // 
            this.dtNSinh.CustomFormat = "dd/MM/yy";
            this.dtNSinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNSinh.Location = new System.Drawing.Point(121, 133);
            this.dtNSinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtNSinh.MaxDate = new System.DateTime(2050, 1, 1, 0, 0, 0, 0);
            this.dtNSinh.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            this.dtNSinh.Name = "dtNSinh";
            this.dtNSinh.Size = new System.Drawing.Size(256, 22);
            this.dtNSinh.TabIndex = 25;
            this.dtNSinh.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(437, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "CMND";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(437, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "SDT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Ngày sinh";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(437, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Địa chỉ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Họ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(437, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Phái";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Mã";
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(496, 135);
            this.txtCMND.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(284, 22);
            this.txtCMND.TabIndex = 29;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(496, 94);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(284, 22);
            this.txtSDT.TabIndex = 28;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(93, 94);
            this.txtTen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(284, 22);
            this.txtTen.TabIndex = 16;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(496, 57);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(284, 22);
            this.txtDiaChi.TabIndex = 27;
            // 
            // txtHo
            // 
            this.txtHo.Location = new System.Drawing.Point(93, 57);
            this.txtHo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHo.Name = "txtHo";
            this.txtHo.Size = new System.Drawing.Size(284, 22);
            this.txtHo.TabIndex = 15;
            // 
            // txtPhai
            // 
            this.txtPhai.Location = new System.Drawing.Point(496, 24);
            this.txtPhai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhai.Name = "txtPhai";
            this.txtPhai.Size = new System.Drawing.Size(284, 22);
            this.txtPhai.TabIndex = 26;
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(93, 24);
            this.txtMa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(284, 22);
            this.txtMa.TabIndex = 14;
            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 521);
            this.Controls.Add(this.grp_NhanVien);
            this.Controls.Add(this.dgvNhanVien);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ NHÂN VIÊN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNhanVien_FormClosing);
            this.Load += new System.EventHandler(this.frmNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.grp_NhanVien.ResumeLayout(false);
            this.grp_NhanVien.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.GroupBox grp_NhanVien;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DateTimePicker dtNSinh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtHo;
        private System.Windows.Forms.TextBox txtPhai;
        private System.Windows.Forms.TextBox txtMa;
    }
}