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
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadThongTinNhaCungCap();
        }
        SqlConnection con = new SqlConnection(ConnectionSQL.getConnectSQL());

        //connet sql at school
        //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=QUANLYSTCOOPFOOD;Integrated Security=True");
        //tao ket noi
        //SqlConnection con = new SqlConnection("Data Source=THONGJ4" + KiTu() + "SQLEXPRESS;Initial Catalog=QUANLYSTCOOPFOOD;Integrated Security=True");

       
       
        //load thong tin nha cung cap
        void LoadThongTinNhaCungCap()
        {
           

            
            try
            {
                con.Open();
                SqlCommand cmdNhaCungCap = new SqlCommand();
                cmdNhaCungCap.CommandText = "sp_LayNCC";
                cmdNhaCungCap.CommandType = CommandType.StoredProcedure;
                cmdNhaCungCap.Connection = con;

                SqlDataAdapter da = new SqlDataAdapter(cmdNhaCungCap);
                DataTable dtNhaCungCap = new DataTable();
                da.Fill(dtNhaCungCap);
                dgvNhaCungCap.DataSource = dtNhaCungCap;

                dgvNhaCungCap.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex);
            }
            finally
            {
                con.Close();
                //LoadThongTinNhaCungCap();
            }
               
        }

        private void dgvNhaCungCap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvNhaCungCap.Rows[e.RowIndex];
            txtMaNCC.Text = Convert.ToString(row.Cells["MANCC"].Value);
            txtTenNCC.Text = Convert.ToString(row.Cells["TENNCC"].Value);
            txtDiaChi.Text = Convert.ToString(row.Cells["DCHI"].Value);
            txtSDT.Text = Convert.ToString(row.Cells["SDT"].Value);
            txtEmail.Text = Convert.ToString(row.Cells["EMAIL"].Value);
        }



        private void frmNhaCungCap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = new DialogResult();
            rs = MessageBox.Show("Bạn có muốn đóng cửa sổ quản lý nhà cung cấp không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
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
        public bool KTThongTin()
        {
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
                return false;
            }

            if (txtTenNCC.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNCC.Focus();
                return false;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập email nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return false;
            }

            if (txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return false;

            }
            else if (Check.CheckDigit(txtSDT.Text) == false || txtSDT.Text.Length < 10 || txtSDT.Text.Length > 11)
            {
                MessageBox.Show("Vui lòng không nhập số điện thoại là kí tự khác ngoài kí tự số và có độ dài là 10 hoặc 11 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {         
                int count = 0;
                count = dgvNhaCungCap.Rows.Count;
                string chuoi = "";
                int chuoi2 = 0;
                chuoi = Convert.ToString(dgvNhaCungCap.Rows[count - 2].Cells[0].Value);
                chuoi2 = Convert.ToInt32((chuoi.Remove(0, 3)));
                if (chuoi2 + 1 < 10)
                {
                    txtMaNCC.Text = "NCC0" + (chuoi2 + 1).ToString();
                }
                else if (chuoi2 + 1 < 100)
                {
                    txtMaNCC.Text = "NCC" + (chuoi2 + 1).ToString();
                }
                if (KTThongTin() == true)
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmdThemNCC = new SqlCommand();
                        cmdThemNCC.CommandText = "sp_ThemNCC";
                        cmdThemNCC.CommandType = CommandType.StoredProcedure;
                        cmdThemNCC.Connection = con;

                        SqlParameter parMaNCC = new SqlParameter("@MANCC", SqlDbType.NVarChar);
                        parMaNCC.Value = txtMaNCC.Text;
                        cmdThemNCC.Parameters.Add(parMaNCC);

                        SqlParameter parTenNCC = new SqlParameter("@TENNCC", SqlDbType.NVarChar);
                        parTenNCC.Value = txtTenNCC.Text;
                        cmdThemNCC.Parameters.Add(parTenNCC);

                        SqlParameter parDiaChi = new SqlParameter("@DCHI", SqlDbType.NVarChar);
                        parDiaChi.Value = txtDiaChi.Text;
                        cmdThemNCC.Parameters.Add(parDiaChi);

                        SqlParameter parSDT = new SqlParameter("@SDT", SqlDbType.NVarChar);
                        parSDT.Value = txtSDT.Text;
                        cmdThemNCC.Parameters.Add(parSDT);

                        SqlParameter parEmail = new SqlParameter("@EMAIL", SqlDbType.NVarChar);
                        parEmail.Value = txtEmail.Text;
                        cmdThemNCC.Parameters.Add(parEmail);

                        if (cmdThemNCC.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Đã thêm thành công", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Thêm nhà cung cấp thất bại", "Thông báo");
                        }
                        dgvNhaCungCap.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi " + ex);
                    }
                    finally
                    {
                        //Reset();
                        con.Close();
                        LoadThongTinNhaCungCap();
                    }
                }
          
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhà cung cấp cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
            }
            else
            {
                try
                {
                    // MỞ
                    con.Open();
                    //KHAI BÁO CMD
                    SqlCommand cmdXoa = new SqlCommand();
                    cmdXoa.CommandText = "sp_XOANCC";
                    cmdXoa.CommandType = CommandType.StoredProcedure;
                    cmdXoa.Connection = con;
                    cmdXoa.Parameters.Add("@MANCC", SqlDbType.NVarChar).Value = txtMaNCC.Text;
                    //THỰC THI
                    cmdXoa.ExecuteNonQuery();
                    dgvNhaCungCap.Refresh();
                    MessageBox.Show("Đã xóa nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                    //Reset();
                    LoadThongTinNhaCungCap();
                }
            }
           
        }
        //Reset thông tin
        private void Reset()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
        }
        //Sửa thông tin
        private void btnSua_Click(object sender, EventArgs e)
        {
           
            
            
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhà cung cấp cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
            }
            else if (KTThongTin())
            {

                try
                {
                    con.Open();
                    SqlCommand cmdSua = new SqlCommand();
                    cmdSua.CommandText = "sp_SuaNCC";
                    cmdSua.CommandType = CommandType.StoredProcedure;
                    cmdSua.Connection = con;
                    cmdSua.Parameters.Add(@"MANCC", SqlDbType.NChar).Value = txtMaNCC.Text;
                    cmdSua.Parameters.Add(@"TENNCC", SqlDbType.NChar).Value = txtTenNCC.Text;
                    cmdSua.Parameters.Add(@"DCHI", SqlDbType.NChar).Value = txtDiaChi.Text;
                    cmdSua.Parameters.Add(@"SDT", SqlDbType.NChar).Value = txtSDT.Text;
                    cmdSua.Parameters.Add(@"EMAIL", SqlDbType.NChar).Value = txtEmail.Text;
                    cmdSua.ExecuteNonQuery();
                    MessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();
                    Reset();
                    LoadThongTinNhaCungCap();
                }
            }
          
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}