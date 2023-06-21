using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace COOPFOOD
{
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadThongTinHoaDon();
            load_cboMaHoaDon();
            load_cboMaKH();
            load_cboMANV();
            load_cboMaHang();
        }
        //Kết nối db
        //connect sql at school
        //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=QUANLYSTCOOPFOOD;Integrated Security=True");
        SqlConnection con = new SqlConnection(ConnectionSQL.getConnectSQL());

        //connet sql at home
        //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=QUANLYSTCOOPFOOD;Integrated Security=True");

        //SqlConnection con = new SqlConnection("Data Source=THONGJ4" + KiTu() + "SQLEXPRESS;Initial Catalog=QUANLYSTCOOPFOOD;Integrated Security=True");

        //----------------------------------------------------------------------------------------------------------------------------------------------
        Dictionary<string, HangHoa> hh = new Dictionary<string, HangHoa>();
        struct HangHoa
        {
            public string Ma;
            public string Ten;
            public int Gia;
            public HangHoa(string ma, string ten, int gia)
            {
                this.Ma = ma;
                this.Ten = ten;
                this.Gia = gia;
            }
        }
        struct Parameter
        {
            public string name;
            public object value;
            public SqlDbType type;
            public Parameter(string name, SqlDbType type, object value)
            {
                this.name = name;
                this.type = type;
                this.value = value;
            }
        }
        SqlCommand buildCommandQuery(string cmdName, params Parameter[] args)
        {
            try
            {
                var dt = new DataTable();
                if (con.State != ConnectionState.Open) { con.Open(); }
                SqlCommand cmd = new SqlCommand(cmdName, con);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var arg in args)
                {
                    cmd.Parameters.Add(new SqlParameter(arg.name, arg.type) { Value = arg.value });
                }
                return cmd;
            }
            catch (Exception ex) { }

            return null;
        }
        int executeCommand(string cmdName, params Parameter[] args)
        {
            var cmd = buildCommandQuery(cmdName, args);
            if (cmd == null) return -1;

            return cmd.ExecuteNonQuery();
        }
        DataTable fillCommandQuery(string cmdName, params Parameter[] args)
        {
            return fillCommandQuery(buildCommandQuery(cmdName, args));
        }
        DataTable fillCommandQuery(SqlCommand cmd)
        {
            if (cmd == null) { return null; }
            var dt = new DataTable();
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        //Load thông tin hóa đơn
        void LoadThongTinHoaDon()
        {
            try
            {
                con.Open();
                SqlCommand cmdHoaDon = new SqlCommand();
                cmdHoaDon.CommandText = "sp_LAYDSHD";
                cmdHoaDon.CommandType = CommandType.StoredProcedure;

                cmdHoaDon.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmdHoaDon);
                DataTable dtHoaDon = new DataTable();
                da.Fill(dtHoaDon);
                dgv_HD.DataSource = dtHoaDon;
                dgv_HD.Refresh();

            }
            catch (Exception e)
            {

                MessageBox.Show("Lỗi " + e, "Thông báo");
            }
            finally
            {
                con.Close();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            int count = 0;
            count = dgv_HD.Rows.Count;
            string chuoi = "";
            int chuoi2 = 0;
            chuoi = Convert.ToString(dgv_HD.Rows[count - 2].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi.Remove(0, 2)));
            if (chuoi2 + 1 < 10)
            {
                txtMaHD.Text = "HD0" + (chuoi2 + 1).ToString();
            }
            else if (chuoi2 + 1 < 100)
            {
                txtMaHD.Text = "HD" + (chuoi2 + 1).ToString();
            }
            if (KTThongTin() == true)
            {
                try
                {
                    con.Open();
                    SqlCommand cmdThemHD = new SqlCommand();
                    cmdThemHD.CommandText = "sp_THEMHD";
                    cmdThemHD.CommandType = CommandType.StoredProcedure;
                    cmdThemHD.Connection = con;

                    //mã hd
                    SqlParameter parMaHD = new SqlParameter("@MAHD", SqlDbType.NVarChar);
                    parMaHD.Value = txtMaHD.Text;
                    cmdThemHD.Parameters.Add(parMaHD);

                    //ngày lập
                    SqlParameter parNgayLap = new SqlParameter("@NGAYLAP", SqlDbType.Date);
                    parNgayLap.Value = dtpHoaDon.Text;
                    cmdThemHD.Parameters.Add(parNgayLap);
                    //phương thức thanh toán
                    SqlParameter parPTTT = new SqlParameter("@PTTHANHTOAN", SqlDbType.NVarChar);
                    parPTTT.Value = cboPTTT.Text;
                    cmdThemHD.Parameters.Add(parPTTT);
                    //mã nhân viên
                    SqlParameter parMaNV = new SqlParameter("@MANV", SqlDbType.NVarChar);
                    parMaNV.Value = cbo_NhanVien.Text;
                    cmdThemHD.Parameters.Add(parMaNV);
                    //mã khách hàng
                    SqlParameter parMaKH = new SqlParameter("@MAKH", SqlDbType.NVarChar);
                    parMaKH.Value = cbo_KhachHang.Text;
                    cmdThemHD.Parameters.Add(parMaKH);
                    //tiền khách trả
                    SqlParameter parTienKHTra = new SqlParameter("@TIENKHACHTRA", SqlDbType.Int);
                    parTienKHTra.Value = txtTienKHTra.Text;
                    cmdThemHD.Parameters.Add(parTienKHTra);

                    if (cmdThemHD.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Thêm hóa đơn thành công", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Thêm hóa đơn thất bại", "Thông báo");
                    }
                    dgv_HD.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex);
                }
                finally
                {
                    con.Close();
                    Reset();
                    load_cboMaHoaDon();
                    load_cboMaHang();
                    LoadThongTinHoaDon();
                }
            }


        }
        public bool KTThongTin()
        {
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHD.Focus();
                return false;
            }
            if (cbo_NhanVien.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên lập hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbo_NhanVien.Focus();
                return false;
            }
            if (cbo_KhachHang.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbo_KhachHang.Focus();
                return false;
            }
            if (cboPTTT.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboPTTT.Focus();
                return false;
            }
            return true;
        }

        private void frmHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = new DialogResult();
            rs = MessageBox.Show("Bạn muốn đóng cửa sổ quản lý hóa đơn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        public static string KiTu()
        {
            char c = (char)92;
            string s = c.ToString();
            return s;
        }

        //load mã hóa đơn
        void load_cboMaHoaDon()
        {
            try
            {

                con.Open();
                cbo_MaHoaDon.Items.Clear();
                cbo_MaHoaDon.SelectedIndex = -1;
                string qry = "SELECT MAHD from HOADON ";
                SqlDataReader dr = new SqlCommand(qry, con).ExecuteReader();
                while (dr.Read())
                {

                    cbo_MaHoaDon.Items.Add(dr.GetValue(0).ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:  " + ex);
            }
        }
        //load mã khách hàng
        void load_cboMaKH()
        {
            try
            {
                con.Open();
                cbo_KhachHang.Items.Clear();
                cbo_KhachHang.SelectedIndex = -1;
                string qry = "SELECT MAKH from KHACHHANG";
                SqlDataReader dr = new SqlCommand(qry, con).ExecuteReader();
                while (dr.Read())
                {
                    cbo_KhachHang.Items.Add(dr.GetValue(0).ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:  " + ex);
            }
        }
        //load mã nhân viên lập hóa đơn
        void load_cboMANV()
        {
            try
            {
                con.Open();
                cbo_NhanVien.Items.Clear();
                cbo_NhanVien.SelectedIndex = -1;
                string qry = "SELECT MANV from NHANVIEN";
                SqlDataReader dr = new SqlCommand(qry, con).ExecuteReader();
                while (dr.Read())
                {
                    cbo_NhanVien.Items.Add(dr.GetValue(0).ToString());

                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:  " + ex);
            }
        }
        //load mã hàng hóa
        void load_cboMaHang()
        {
            try
            {
                con.Open();
                cbo_MaHang.Items.Clear();
                cbo_MaHang.SelectedIndex = -1;
                string qry = "SELECT MAHH from HANGHOA";
                SqlDataReader dr = new SqlCommand(qry, con).ExecuteReader();
                while (dr.Read())
                {
                    cbo_MaHang.Items.Add(dr.GetValue(0).ToString());
                }
                dr.Close();

                var cmd = new SqlCommand("SELECT * FROM [HANGHOA]", con);
                var dt = fillCommandQuery(cmd);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        hh[dt.Rows[i]["MAHH"].ToString()] = new HangHoa(dt.Rows[i]["MAHH"].ToString(), dt.Rows[i]["TENHH"].ToString(), int.Parse(dt.Rows[i]["DONGIA"].ToString()));
                        //hh.Add(dt.Rows[i]["MAHH"].ToString(), new HangHoa(dt.Rows[i]["MAHH"].ToString(), dt.Rows[i]["TENHH"].ToString(), int.Parse(dt.Rows[i]["DONGIA"].ToString())));
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi:  " + ex);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn cần xóa", "Thông báo");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmdXoa = new SqlCommand();
                    cmdXoa.CommandText = "sp_XOAHD";
                    cmdXoa.CommandType = CommandType.StoredProcedure;
                    cmdXoa.Connection = con;
                    cmdXoa.Parameters.Add("@MAHD", SqlDbType.NVarChar).Value = txtMaHD.Text;
                    cmdXoa.ExecuteNonQuery();
                    MessageBox.Show("Đã xóa hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (txtMaHD.Text == cbo_MaHoaDon.Text)
                    {
                        dgv_HDCT.DataSource = null;
                        dgv_HDCT.Refresh();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi " + ex);
                }
                finally
                {
                    con.Close();
                    Reset();
                    load_cboMaHoaDon();
                    load_cboMaHang();
                    LoadThongTinHoaDon();
                }
            }

        }

        void Reset()
        {
            txtMaHD.Text = "";
            cboPTTT.Text = null;
            cbo_KhachHang.Text = null;
            cbo_NhanVien.Text = null;
            dtpHoaDon.Text = "15/12/2022";
            //dtpHoaDon.Text = "12/15/2022";
            txtTienKHTra.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn cần sửa", "Thông báo");
            }
            else
            {
                try
                {
                    if (KTThongTin())
                    {
                        con.Open();
                        SqlCommand cmdSua = new SqlCommand();
                        cmdSua.CommandText = "sp_SUAHD";
                        cmdSua.CommandType = CommandType.StoredProcedure;
                        cmdSua.Connection = con;

                        cmdSua.Parameters.Add("@MAHD", SqlDbType.NVarChar).Value = txtMaHD.Text;
                        cmdSua.Parameters.Add("@NGAYLAP", SqlDbType.Date).Value = dtpHoaDon.Text;
                        cmdSua.Parameters.Add("@PTTHANHTOAN", SqlDbType.NVarChar).Value = cboPTTT.Text;
                        cmdSua.Parameters.Add("@MANV", SqlDbType.NVarChar).Value = cbo_NhanVien.Text;
                        cmdSua.Parameters.Add("@MAKH", SqlDbType.NVarChar).Value = cbo_KhachHang.Text;
                        cmdSua.Parameters.Add("@TIENKHACHTRA", SqlDbType.Int).Value = txtTienKHTra.Text;
                        cmdSua.ExecuteNonQuery();
                        MessageBox.Show("Sửa thông tin hóa đơn thành công", "Thông báo");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Lỗi: " + ex);
                }
                finally
                {
                    con.Close();
                    Reset();
                    load_cboMaHoaDon();
                    load_cboMaHang();
                    LoadThongTinHoaDon();
                }
            }
        }

        private void cbo_MaHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show((sender as ComboBox).SelectedItem.ToString(), "Index");
            try
            {
                var t = (ComboBox)sender;
                LoadHoaDonCT(t.SelectedItem);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex, "Thông báo");
            }

        }

        private void cbo_MaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maHH = cbo_MaHang.Text;
            if (hh.ContainsKey(maHH))
            {
                txt_TenHang.Text = hh[maHH].Ten;
                txt_DonGia.Text = hh[maHH].Gia.ToString();
            }
        }

        private void btn_ThemHDCT_Click(object sender, EventArgs e)
        {
            if (!KTThongTinHDCT()) return;
            var cmd = buildCommandQuery(
                   "sp_THEMHDCT",
                   new Parameter("@MAHD", SqlDbType.NVarChar, cbo_MaHoaDon.Text),
                   new Parameter("@MAHH", SqlDbType.NVarChar, cbo_MaHang.Text),
                   new Parameter("@SOLUONG", SqlDbType.Int, txt_SoLuong.Text)
               );
            try
            {
                //thực thi
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đã thêm chi tiết hóa đơn thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Thêm chi tiết hóa đơn thất bại", "Thông báo");
                }

                dgv_HDCT.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex);
            }
            finally
            {
                LoadHoaDonCT(cbo_MaHoaDon.SelectedItem);
            }
        }
        void ResetHDCT()
        {
            cbo_MaHoaDon.Text = null;
            cbo_MaHang.Text = null;
            txt_TenHang.Text = "";
            txt_SoLuong.Text = "";
            txt_DonGia.Text = "";
            txt_ThanhTien.Text = "";
        }
        void LoadHoaDonCT(object maHD)
        {
            var dt = fillCommandQuery(
                "sp_LAYHDCT",
                new Parameter("@MAHD", SqlDbType.NVarChar, cbo_MaHoaDon.SelectedItem)
            );
            if (dt != null)
            {
                dgv_HDCT.DataSource = dt;
                dgv_HDCT.Refresh();
            }
        }

        public bool KTThongTinHDCT()
        {
            if (cbo_MaHoaDon.Text == "")
            {
                MessageBox.Show("Vui lòng chọn mã hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHD.Focus();
                return false;
            }
            if (cbo_MaHang.Text == "")
            {
                MessageBox.Show("Vui lòng chọn mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbo_NhanVien.Focus();
                return false;
            }
            if (txt_SoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbo_KhachHang.Focus();
                return false;
            }
            return true;
        }

        private void btn_SuaHDCT_Click(object sender, EventArgs e)
        {
            if (!KTThongTinHDCT()) return;

            var cmd = buildCommandQuery(
                   "sp_SUAHDCT",
                   new Parameter("@MAHD", SqlDbType.NVarChar, cbo_MaHoaDon.Text),
                   new Parameter("@MAHH", SqlDbType.NVarChar, cbo_MaHang.Text),
                   new Parameter("@SOLUONG", SqlDbType.Int, txt_SoLuong.Text)
               );
            try
            {
                //thực thi
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đã sửa chi tiết hóa đơn thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Sửa chi tiết hóa đơn thất bại", "Thông báo");
                }

                dgv_HDCT.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex);
            }
            finally
            {
                LoadHoaDonCT(cbo_MaHoaDon.SelectedItem);
            }
        }

        private void txt_SoLuong_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txt_ThanhTien.Text = (txt_SoLuong.Value * int.Parse(txt_DonGia.Text)).ToString();
            }
            catch { }
        }


        private void dgv_HDCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = new DataGridViewRow();
            row = dgv_HDCT.Rows[e.RowIndex];
            cbo_MaHoaDon.Text = Convert.ToString(row.Cells["MAHD"].Value);
            cbo_MaHang.Text = Convert.ToString(row.Cells["MAHH"].Value);
            txt_SoLuong.Text = Convert.ToString(row.Cells["SOLUONG"].Value);
            txt_ThanhTien.Text = Convert.ToString(row.Cells["TONGTIENHH"].Value);
            if (hh.ContainsKey(cbo_MaHang.Text))
            {
                txt_TenHang.Text = hh[cbo_MaHang.Text].Ten;
                txt_DonGia.Text = hh[cbo_MaHang.Text].Gia.ToString();

            }
            else
            {
                txt_TenHang.Text = "";
                txt_DonGia.Text = "";
            }
        }

        private void dgv_HD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = new DataGridViewRow();
            row = dgv_HD.Rows[e.RowIndex];
            txtMaHD.Text = Convert.ToString(row.Cells["MAHD"].Value);
            dtpHoaDon.Text = Convert.ToString(row.Cells["NGAYLAP"].Value);
            cbo_KhachHang.Text = Convert.ToString(row.Cells["MAKH"].Value);
            txtTienKHTra.Text = Convert.ToString(row.Cells["TIENKHACHTRA"].Value);
            cbo_NhanVien.Text = Convert.ToString(row.Cells["MANV"].Value);
            cboPTTT.Text = Convert.ToString(row.Cells["PTTHANHTOAN"].Value);

        }

        private void btn_XoaHDCT_Click(object sender, EventArgs e)
        {
            var result = executeCommand(
                "sp_XOAHDCT",
                new Parameter("@MAHD", SqlDbType.NVarChar, cbo_MaHoaDon.Text),
                new Parameter("@MAHH", SqlDbType.NVarChar, cbo_MaHang.Text)
            );
            if (result > 0)
            {
                MessageBox.Show("Xóa chi tiết hóa đơn thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Xóa chi tiết hóa đơn thất bại", "Thông báo");
            }
            LoadHoaDonCT(cbo_MaHoaDon.SelectedItem);
        }
    }
}
