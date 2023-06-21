namespace COOPFOOD
{
    partial class frmHangHoa
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
            this.dgvHangHoa = new System.Windows.Forms.DataGridView();
            this.lblHangHoa = new System.Windows.Forms.Label();
            this.grpHangHoa = new System.Windows.Forms.GroupBox();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.lblMaNCC = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblHanSuDung = new System.Windows.Forms.Label();
            this.lblNgaySX = new System.Windows.Forms.Label();
            this.dtpHSD = new System.Windows.Forms.DateTimePicker();
            this.dtpNgaySX = new System.Windows.Forms.DateTimePicker();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtLoaiHangHoa = new System.Windows.Forms.TextBox();
            this.lblLoaiHangHoa = new System.Windows.Forms.Label();
            this.txtTenHangHoa = new System.Windows.Forms.TextBox();
            this.lblTenHangHoa = new System.Windows.Forms.Label();
            this.txtMaHangHoa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            this.grpHangHoa.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHangHoa
            // 
            this.dgvHangHoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangHoa.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvHangHoa.Location = new System.Drawing.Point(0, 341);
            this.dgvHangHoa.Name = "dgvHangHoa";
            this.dgvHangHoa.RowTemplate.Height = 24;
            this.dgvHangHoa.Size = new System.Drawing.Size(920, 227);
            this.dgvHangHoa.TabIndex = 0;
            this.dgvHangHoa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHangHoa_CellContentClick);
            // 
            // lblHangHoa
            // 
            this.lblHangHoa.AutoSize = true;
            this.lblHangHoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHangHoa.ForeColor = System.Drawing.Color.Red;
            this.lblHangHoa.Location = new System.Drawing.Point(349, 26);
            this.lblHangHoa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHangHoa.Name = "lblHangHoa";
            this.lblHangHoa.Size = new System.Drawing.Size(225, 42);
            this.lblHangHoa.TabIndex = 1;
            this.lblHangHoa.Text = "HÀNG HÓA";
            // 
            // grpHangHoa
            // 
            this.grpHangHoa.Controls.Add(this.txtMaNCC);
            this.grpHangHoa.Controls.Add(this.lblMaNCC);
            this.grpHangHoa.Controls.Add(this.btnThem);
            this.grpHangHoa.Controls.Add(this.btnReset);
            this.grpHangHoa.Controls.Add(this.btnXoa);
            this.grpHangHoa.Controls.Add(this.btnSua);
            this.grpHangHoa.Controls.Add(this.btnThoat);
            this.grpHangHoa.Controls.Add(this.lblHanSuDung);
            this.grpHangHoa.Controls.Add(this.lblNgaySX);
            this.grpHangHoa.Controls.Add(this.dtpHSD);
            this.grpHangHoa.Controls.Add(this.dtpNgaySX);
            this.grpHangHoa.Controls.Add(this.txtDonGia);
            this.grpHangHoa.Controls.Add(this.lblDonGia);
            this.grpHangHoa.Controls.Add(this.txtSoLuong);
            this.grpHangHoa.Controls.Add(this.lblSoLuong);
            this.grpHangHoa.Controls.Add(this.txtLoaiHangHoa);
            this.grpHangHoa.Controls.Add(this.lblLoaiHangHoa);
            this.grpHangHoa.Controls.Add(this.txtTenHangHoa);
            this.grpHangHoa.Controls.Add(this.lblTenHangHoa);
            this.grpHangHoa.Controls.Add(this.txtMaHangHoa);
            this.grpHangHoa.Controls.Add(this.label1);
            this.grpHangHoa.Location = new System.Drawing.Point(12, 69);
            this.grpHangHoa.Name = "grpHangHoa";
            this.grpHangHoa.Size = new System.Drawing.Size(896, 266);
            this.grpHangHoa.TabIndex = 2;
            this.grpHangHoa.TabStop = false;
            this.grpHangHoa.Text = "Thông tin hàng hóa";
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Location = new System.Drawing.Point(162, 91);
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(240, 22);
            this.txtMaNCC.TabIndex = 36;
            // 
            // lblMaNCC
            // 
            this.lblMaNCC.AutoSize = true;
            this.lblMaNCC.Location = new System.Drawing.Point(39, 94);
            this.lblMaNCC.Name = "lblMaNCC";
            this.lblMaNCC.Size = new System.Drawing.Size(121, 17);
            this.lblMaNCC.TabIndex = 35;
            this.lblMaNCC.Text = "Mã nhà cung cấp:";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Aqua;
            this.btnThem.Location = new System.Drawing.Point(76, 216);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(116, 43);
            this.btnThem.TabIndex = 30;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Lime;
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReset.Location = new System.Drawing.Point(546, 216);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(116, 42);
            this.btnReset.TabIndex = 34;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Red;
            this.btnXoa.Location = new System.Drawing.Point(396, 216);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(116, 42);
            this.btnXoa.TabIndex = 32;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSua.Location = new System.Drawing.Point(231, 216);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(116, 43);
            this.btnSua.TabIndex = 31;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThoat.Location = new System.Drawing.Point(698, 217);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(116, 42);
            this.btnThoat.TabIndex = 33;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblHanSuDung
            // 
            this.lblHanSuDung.AutoSize = true;
            this.lblHanSuDung.Location = new System.Drawing.Point(476, 175);
            this.lblHanSuDung.Name = "lblHanSuDung";
            this.lblHanSuDung.Size = new System.Drawing.Size(93, 17);
            this.lblHanSuDung.TabIndex = 29;
            this.lblHanSuDung.Text = "Hạn sử dụng:";
            // 
            // lblNgaySX
            // 
            this.lblNgaySX.AutoSize = true;
            this.lblNgaySX.Location = new System.Drawing.Point(476, 135);
            this.lblNgaySX.Name = "lblNgaySX";
            this.lblNgaySX.Size = new System.Drawing.Size(102, 17);
            this.lblNgaySX.TabIndex = 28;
            this.lblNgaySX.Text = "Ngày sản xuất:";
            // 
            // dtpHSD
            // 
            this.dtpHSD.CustomFormat = "dd/MM/yyyy";
            this.dtpHSD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHSD.Location = new System.Drawing.Point(597, 170);
            this.dtpHSD.MaxDate = new System.DateTime(2050, 1, 1, 0, 0, 0, 0);
            this.dtpHSD.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.dtpHSD.Name = "dtpHSD";
            this.dtpHSD.Size = new System.Drawing.Size(249, 22);
            this.dtpHSD.TabIndex = 27;
            this.dtpHSD.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            // 
            // dtpNgaySX
            // 
            this.dtpNgaySX.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySX.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySX.Location = new System.Drawing.Point(597, 130);
            this.dtpNgaySX.MaxDate = new System.DateTime(2050, 1, 1, 0, 0, 0, 0);
            this.dtpNgaySX.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.dtpNgaySX.Name = "dtpNgaySX";
            this.dtpNgaySX.Size = new System.Drawing.Size(249, 22);
            this.dtpNgaySX.TabIndex = 26;
            this.dtpNgaySX.Value = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(597, 91);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(249, 22);
            this.txtDonGia.TabIndex = 25;
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(476, 96);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(61, 17);
            this.lblDonGia.TabIndex = 24;
            this.lblDonGia.Text = "Đơn giá:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(597, 54);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(249, 22);
            this.txtSoLuong.TabIndex = 23;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(476, 59);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(104, 17);
            this.lblSoLuong.TabIndex = 22;
            this.lblSoLuong.Text = "Số lượng nhập:";
            // 
            // txtLoaiHangHoa
            // 
            this.txtLoaiHangHoa.Location = new System.Drawing.Point(162, 167);
            this.txtLoaiHangHoa.Name = "txtLoaiHangHoa";
            this.txtLoaiHangHoa.Size = new System.Drawing.Size(240, 22);
            this.txtLoaiHangHoa.TabIndex = 21;
            // 
            // lblLoaiHangHoa
            // 
            this.lblLoaiHangHoa.AutoSize = true;
            this.lblLoaiHangHoa.Location = new System.Drawing.Point(39, 172);
            this.lblLoaiHangHoa.Name = "lblLoaiHangHoa";
            this.lblLoaiHangHoa.Size = new System.Drawing.Size(103, 17);
            this.lblLoaiHangHoa.TabIndex = 20;
            this.lblLoaiHangHoa.Text = "Loại hàng hóa:";
            // 
            // txtTenHangHoa
            // 
            this.txtTenHangHoa.Location = new System.Drawing.Point(162, 128);
            this.txtTenHangHoa.Name = "txtTenHangHoa";
            this.txtTenHangHoa.Size = new System.Drawing.Size(240, 22);
            this.txtTenHangHoa.TabIndex = 19;
            // 
            // lblTenHangHoa
            // 
            this.lblTenHangHoa.AutoSize = true;
            this.lblTenHangHoa.Location = new System.Drawing.Point(39, 130);
            this.lblTenHangHoa.Name = "lblTenHangHoa";
            this.lblTenHangHoa.Size = new System.Drawing.Size(101, 17);
            this.lblTenHangHoa.TabIndex = 18;
            this.lblTenHangHoa.Text = "Tên hàng hóa:";
            // 
            // txtMaHangHoa
            // 
            this.txtMaHangHoa.Location = new System.Drawing.Point(162, 54);
            this.txtMaHangHoa.Name = "txtMaHangHoa";
            this.txtMaHangHoa.Size = new System.Drawing.Size(240, 22);
            this.txtMaHangHoa.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Mã hàng hóa:";
            // 
            // frmHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 568);
            this.Controls.Add(this.grpHangHoa);
            this.Controls.Add(this.lblHangHoa);
            this.Controls.Add(this.dgvHangHoa);
            this.Name = "frmHangHoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ HÀNG HÓA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHangHoa_FormClosing);
            this.Load += new System.EventHandler(this.frmHangHoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            this.grpHangHoa.ResumeLayout(false);
            this.grpHangHoa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHangHoa;
        private System.Windows.Forms.Label lblHangHoa;
        private System.Windows.Forms.GroupBox grpHangHoa;
        private System.Windows.Forms.Label lblHanSuDung;
        private System.Windows.Forms.Label lblNgaySX;
        private System.Windows.Forms.DateTimePicker dtpHSD;
        private System.Windows.Forms.DateTimePicker dtpNgaySX;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtLoaiHangHoa;
        private System.Windows.Forms.Label lblLoaiHangHoa;
        private System.Windows.Forms.TextBox txtTenHangHoa;
        private System.Windows.Forms.Label lblTenHangHoa;
        private System.Windows.Forms.TextBox txtMaHangHoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtMaNCC;
        private System.Windows.Forms.Label lblMaNCC;
    }
}