namespace COOPFOOD
{
    partial class frmNhaCungCap
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
            this.lblNhaCungCap = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblPhoneNum = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dgvNhaCungCap = new System.Windows.Forms.DataGridView();
            this.grpThongTinNCC = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhaCungCap)).BeginInit();
            this.grpThongTinNCC.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNhaCungCap
            // 
            this.lblNhaCungCap.AutoSize = true;
            this.lblNhaCungCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhaCungCap.ForeColor = System.Drawing.Color.Red;
            this.lblNhaCungCap.Location = new System.Drawing.Point(301, 23);
            this.lblNhaCungCap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(316, 42);
            this.lblNhaCungCap.TabIndex = 1;
            this.lblNhaCungCap.Text = "NHÀ CUNG CẤP";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(43, 36);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(117, 17);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "Mã nhà cung cấp";
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Location = new System.Drawing.Point(196, 31);
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(245, 22);
            this.txtMaNCC.TabIndex = 3;
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(196, 69);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(245, 22);
            this.txtTenNCC.TabIndex = 5;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(43, 74);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(123, 17);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Tên nhà cung cấp";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(196, 109);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(245, 22);
            this.txtDiaChi.TabIndex = 7;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(43, 114);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(51, 17);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Địa chỉ";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(609, 31);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(282, 22);
            this.txtSDT.TabIndex = 9;
            // 
            // lblPhoneNum
            // 
            this.lblPhoneNum.AutoSize = true;
            this.lblPhoneNum.Location = new System.Drawing.Point(498, 36);
            this.lblPhoneNum.Name = "lblPhoneNum";
            this.lblPhoneNum.Size = new System.Drawing.Size(91, 17);
            this.lblPhoneNum.TabIndex = 8;
            this.lblPhoneNum.Text = "Số điện thoại";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(609, 71);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(282, 22);
            this.txtEmail.TabIndex = 11;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(498, 74);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 17);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Aqua;
            this.btnThem.Location = new System.Drawing.Point(117, 210);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(116, 43);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSua.Location = new System.Drawing.Point(268, 144);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(116, 43);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Red;
            this.btnXoa.Location = new System.Drawing.Point(433, 144);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(116, 42);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThoat.Location = new System.Drawing.Point(735, 145);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(116, 42);
            this.btnThoat.TabIndex = 15;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dgvNhaCungCap
            // 
            this.dgvNhaCungCap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhaCungCap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvNhaCungCap.Location = new System.Drawing.Point(0, 264);
            this.dgvNhaCungCap.Name = "dgvNhaCungCap";
            this.dgvNhaCungCap.RowTemplate.Height = 24;
            this.dgvNhaCungCap.Size = new System.Drawing.Size(932, 271);
            this.dgvNhaCungCap.TabIndex = 16;
            this.dgvNhaCungCap.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhaCungCap_CellContentClick);
            // 
            // grpThongTinNCC
            // 
            this.grpThongTinNCC.Controls.Add(this.btnReset);
            this.grpThongTinNCC.Controls.Add(this.btnXoa);
            this.grpThongTinNCC.Controls.Add(this.lblCode);
            this.grpThongTinNCC.Controls.Add(this.btnSua);
            this.grpThongTinNCC.Controls.Add(this.txtMaNCC);
            this.grpThongTinNCC.Controls.Add(this.btnThoat);
            this.grpThongTinNCC.Controls.Add(this.lblPhoneNum);
            this.grpThongTinNCC.Controls.Add(this.txtSDT);
            this.grpThongTinNCC.Controls.Add(this.lblEmail);
            this.grpThongTinNCC.Controls.Add(this.txtDiaChi);
            this.grpThongTinNCC.Controls.Add(this.txtEmail);
            this.grpThongTinNCC.Controls.Add(this.lblAddress);
            this.grpThongTinNCC.Controls.Add(this.lblName);
            this.grpThongTinNCC.Controls.Add(this.txtTenNCC);
            this.grpThongTinNCC.Location = new System.Drawing.Point(0, 65);
            this.grpThongTinNCC.Name = "grpThongTinNCC";
            this.grpThongTinNCC.Size = new System.Drawing.Size(932, 201);
            this.grpThongTinNCC.TabIndex = 17;
            this.grpThongTinNCC.TabStop = false;
            this.grpThongTinNCC.Text = "Thông tin nhà cung cấp";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Lime;
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReset.Location = new System.Drawing.Point(583, 144);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(116, 42);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 535);
            this.Controls.Add(this.dgvNhaCungCap);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.lblNhaCungCap);
            this.Controls.Add(this.grpThongTinNCC);
            this.Name = "frmNhaCungCap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ NHÀ CUNG CẤP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNhaCungCap_FormClosing);
            this.Load += new System.EventHandler(this.frmNhaCungCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhaCungCap)).EndInit();
            this.grpThongTinNCC.ResumeLayout(false);
            this.grpThongTinNCC.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNhaCungCap;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtMaNCC;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblPhoneNum;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dgvNhaCungCap;
        private System.Windows.Forms.GroupBox grpThongTinNCC;
        private System.Windows.Forms.Button btnReset;
    }
}