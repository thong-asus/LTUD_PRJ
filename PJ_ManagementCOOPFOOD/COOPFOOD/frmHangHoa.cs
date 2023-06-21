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
    public partial class frmHangHoa : Form
    {
        public frmHangHoa()
        {
            InitializeComponent();
        }
        //connect sql at school
        SqlConnection con = new SqlConnection(ConnectionSQL.getConnectSQL());

        //connet sql at home
        //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=QUANLYSTCOOPFOOD;Integrated Security=True");

        //SqlConnection con = new SqlConnection("Data Source=THONGJ4" + KiTu() + "SQLEXPRESS;Initial Catalog=QUANLYSTCOOPFOOD;Integrated Security=True");

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            LoadThongTinHangHoa();
        }

        //Load dữ liệu hàng hóa
        void LoadThongTinHangHoa()
        {
            try
            {
                //mở kết nối
                con.Open();
                SqlCommand cmdHangHoa = new SqlCommand();
                cmdHangHoa.CommandText = "sp_LAYDSHH";
                cmdHangHoa.CommandType = CommandType.StoredProcedure;

                cmdHangHoa.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmdHangHoa);
                DataTable dtHangHoa = new DataTable();
                da.Fill(dtHangHoa);
                dgvHangHoa.DataSource = dtHangHoa;

                dgvHangHoa.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex, "Thông báo");
            }
            finally
            {
                con.Close();

            }
        }

        public bool KTThongTin()
        {
            if (txtMaHangHoa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHangHoa.Focus();
                return false;
            }

            if (txtTenHangHoa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHangHoa.Focus();
                return false;
            }
            if (txtLoaiHangHoa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập loại hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLoaiHangHoa.Focus();
                return false;
            }
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng hàng hóa nhập kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return false;

            }
            else if (Check.CheckDigit(txtSoLuong.Text) == false)
            {
                MessageBox.Show("Vui lòng nhập số lượng là số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return false;
            }


            if (txtDonGia.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đơn giá hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonGia.Focus();
                return false;
            }
            if (dtpHSD.Value < dtpNgaySX.Value)
            {
                MessageBox.Show("Hạn sử dụng không thể nhỏ hơn ngày sản xuất, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpHSD.Focus();
                return false;
            }
            return true;
        }
        public static string KiTu()
        {
            char c = (char)92;
            string s = c.ToString();
            return s;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            


                int count = 0;
                count = dgvHangHoa.Rows.Count;
                string chuoi = "";
                int chuoi2 = 0;
                chuoi = Convert.ToString(dgvHangHoa.Rows[count - 2].Cells[0].Value);
                chuoi2 = Convert.ToInt32((chuoi.Remove(0, 2)));
                if (chuoi2 + 1 < 10)
                {
                    txtMaHangHoa.Text = "HH0" + (chuoi2 + 1).ToString();
                }
                else if (chuoi2 + 1 < 100)
                {
                    txtMaHangHoa.Text = "HH" + (chuoi2 + 1).ToString();
                }
                if (KTThongTin() == true)
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmdThemHH = new SqlCommand();
                        cmdThemHH.CommandText = "sp_THEMHH";
                        cmdThemHH.CommandType = CommandType.StoredProcedure;
                        cmdThemHH.Connection = con;

                        SqlParameter parMaHH = new SqlParameter("@MAHH", SqlDbType.NVarChar);
                        parMaHH.Value = txtMaHangHoa.Text;
                        cmdThemHH.Parameters.Add(parMaHH);

                        SqlParameter parMaNCC = new SqlParameter("@MANCC", SqlDbType.NVarChar);
                        parMaNCC.Value = txtMaNCC.Text;
                        cmdThemHH.Parameters.Add(parMaNCC);

                        SqlParameter parTenHH = new SqlParameter("@TENHH", SqlDbType.NVarChar);
                        parTenHH.Value = txtTenHangHoa.Text;
                        cmdThemHH.Parameters.Add(parTenHH);

                        SqlParameter parLoaiHH = new SqlParameter("@LOAIHH", SqlDbType.NVarChar);
                        parLoaiHH.Value = txtLoaiHangHoa.Text;
                        cmdThemHH.Parameters.Add(parLoaiHH);

                        SqlParameter parSoLuong = new SqlParameter("@SOLUONG", SqlDbType.NVarChar);
                        parSoLuong.Value = txtSoLuong.Text;
                        cmdThemHH.Parameters.Add(parSoLuong);

                        SqlParameter parDonGia = new SqlParameter("@DONGIA", SqlDbType.Int);
                        parDonGia.Value = txtDonGia.Text;
                        cmdThemHH.Parameters.Add(parDonGia);

                        SqlParameter parNSX = new SqlParameter("@NGAYSX", SqlDbType.Date);
                        parNSX.Value = dtpNgaySX.Value;
                        cmdThemHH.Parameters.Add(parNSX);

                        SqlParameter parHSD = new SqlParameter("@HANSD", SqlDbType.Date);
                        parHSD.Value = dtpHSD.Value;
                        cmdThemHH.Parameters.Add(parHSD);


                        if (cmdThemHH.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Đã thêm thành công", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Thêm hàng hóa thất bại", "Thông báo");
                        }
                        dgvHangHoa.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi " + ex);
                    }
                    finally
                    {
                        con.Close();
                        Reset();
                        LoadThongTinHangHoa();
                    }
                }
            

        }

        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvHangHoa.Rows[e.RowIndex];
            txtMaHangHoa.Text = Convert.ToString(row.Cells["MAHH"].Value);
            txtMaNCC.Text = Convert.ToString(row.Cells["MANCC"].Value);
            txtTenHangHoa.Text = Convert.ToString(row.Cells["TENHH"].Value);
            txtLoaiHangHoa.Text = Convert.ToString(row.Cells["LOAIHH"].Value);
            txtSoLuong.Text = Convert.ToString(row.Cells["SOLUONG"].Value);
            txtDonGia.Text = Convert.ToString(row.Cells["DONGIA"].Value);
            dtpNgaySX.Text = Convert.ToString(row.Cells["NGAYSX"].Value);
            dtpHSD.Text = Convert.ToString(row.Cells["HANSD"].Value);

        }
        private void Reset()
        {
            txtMaHangHoa.Text = "";
            txtTenHangHoa.Text = "";
            txtMaNCC.Text = "";
            txtLoaiHangHoa.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            dtpNgaySX.Text = "01/01/2021";
            dtpHSD.Text = "01/01/2021";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            


                if (txtMaNCC.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mã hàng hóa muốn xóa!!!", "Thông báo");
                }
                else
                {
                    try
                    {

                        con.Open();
                        SqlCommand cmdXoaHH = new SqlCommand();
                        cmdXoaHH.CommandText = "sp_XOAHH";
                        cmdXoaHH.CommandType = CommandType.StoredProcedure;
                        cmdXoaHH.Connection = con;
                        cmdXoaHH.Parameters.Add("@MAHH", SqlDbType.NVarChar).Value = txtMaHangHoa.Text;
                        cmdXoaHH.ExecuteNonQuery();
                        MessageBox.Show("Đã xóa hàng hóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi " + ex);
                    }
                    finally
                    {
                        con.Close();
                        Reset();
                        LoadThongTinHangHoa();
                    }
                }
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           


                if (txtMaHangHoa.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mã hàng hóa cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaHangHoa.Focus();
                }
                else if (KTThongTin())
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmdSua = new SqlCommand();
                        cmdSua.CommandText = "sp_SUAHH";
                        cmdSua.CommandType = CommandType.StoredProcedure;
                        cmdSua.Connection = con;
                        cmdSua.Parameters.Add(@"MAHH", SqlDbType.NChar).Value = txtMaHangHoa.Text;
                        cmdSua.Parameters.Add(@"MANCC", SqlDbType.NChar).Value = txtMaNCC.Text;
                        cmdSua.Parameters.Add(@"TENHH", SqlDbType.NChar).Value = txtTenHangHoa.Text;
                        cmdSua.Parameters.Add(@"LOAIHH", SqlDbType.NChar).Value = txtLoaiHangHoa.Text;
                        cmdSua.Parameters.Add(@"SOLUONG", SqlDbType.Int).Value = txtSoLuong.Text;
                        cmdSua.Parameters.Add(@"DONGIA", SqlDbType.Int).Value = txtDonGia.Text;
                        cmdSua.Parameters.Add(@"NGAYSX", SqlDbType.Date).Value = dtpNgaySX.Value;
                        cmdSua.Parameters.Add(@"HANSD", SqlDbType.Date).Value = dtpHSD.Value;
                        cmdSua.ExecuteNonQuery();
                        MessageBox.Show("Sửa thông tin hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        con.Close();
                        Reset();
                        LoadThongTinHangHoa();
                    }
                }
            
        }

        private void frmHangHoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = new DialogResult();
            rs = MessageBox.Show("Bạn có muốn đóng cửa sổ quản lý hàng hóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
