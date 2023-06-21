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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();

        }

        //connet sql at school
        //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=QUANLYSTCOOPFOOD;Integrated Security=True");
        SqlConnection con = new SqlConnection(ConnectionSQL.getConnectSQL());

        //connet sql at home
        //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=QUANLYSTCOOPFOOD;Integrated Security=True");

        //SqlConnection con = new SqlConnection("Data Source=THONGJ4" + KiTu() + "SQLEXPRESS;Initial Catalog=QUANLYSTCOOPFOOD;Integrated Security=True");
        private void frmThongTin_Load(object sender, EventArgs e)
        {
            LoadDuLieuKhachHang();

        }
        void LoadDuLieuKhachHang()
        {
            try
            {
                //mở kết nối
                con.Open();
                //khai báo command
                SqlCommand cmdKhachHang = new SqlCommand();
                cmdKhachHang.CommandText = "sp_LAYDSKH";
                cmdKhachHang.CommandType = CommandType.StoredProcedure;
                //gắn kết nối
                cmdKhachHang.Connection = con;
                //đối tượng dataAdapter

                SqlDataAdapter da = new SqlDataAdapter(cmdKhachHang);
                DataTable dtKhachHang = new DataTable();
                da.Fill(dtKhachHang);
                dgvKhachHang.DataSource = dtKhachHang;

                //cach 2
                //SqlDataAdapter da = new SqlDataAdapter("SElect* from khachhang", con);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                //dgvKhachHang.DataSource = ds.Tables[0];
                dgvKhachHang.Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi " + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int count = 0;
            count = dgvKhachHang.Rows.Count;
            string chuoi = "";
            int chuoi2 = 0;
            chuoi = Convert.ToString(dgvKhachHang.Rows[count - 2].Cells[0].Value);
            chuoi2 = Convert.ToInt32((chuoi.Remove(0, 2)));
            if(chuoi2+1<10)
            {
                txtMa.Text = "KH0" + (chuoi2 + 1).ToString();
            }
            else if(chuoi2+1<100)
            {
                txtMa.Text = "KH" + (chuoi2 + 1).ToString();
            }
            if (KTThongTin())
            {
               
                try
                {
                    //mở kết nối
                    con.Open();
                    //khai báo command
                    SqlCommand cmdThemKH = new SqlCommand();
                    cmdThemKH.CommandText = "sp_ThemKH";
                    cmdThemKH.CommandType = CommandType.StoredProcedure;
                    cmdThemKH.Connection = con;
                    //Thêm các giá trị tham số (mã khách hàng)
                    SqlParameter parMa = new SqlParameter("@MAKH", SqlDbType.NVarChar);
                    // thêm giá trị
                    parMa.Value = txtMa.Text;
                    //thêm vào command
                    cmdThemKH.Parameters.Add(parMa);
                    //Thêm các giá trị tham số (họ khách hàng)
                    SqlParameter parHo = new SqlParameter("@HOKH", SqlDbType.NVarChar);
                    // thêm giá trị
                    parHo.Value = txtHo.Text;
                    //thêm vào command
                    cmdThemKH.Parameters.Add(parHo);
                    //Thêm các giá trị tham số (tên khách hàng)
                    SqlParameter parTen = new SqlParameter("@TENKH", SqlDbType.NVarChar);
                    // thêm giá trị
                    parTen.Value = txtTen.Text;
                    //thêm vào command
                    cmdThemKH.Parameters.Add(parTen);
                    //Thêm các giá trị tham số (số điện thoại)
                    SqlParameter parSDT = new SqlParameter("@SDT", SqlDbType.NVarChar);
                    // thêm giá trị
                    parSDT.Value = txtSDT.Text;
                    //thêm vào command
                    cmdThemKH.Parameters.Add(parSDT);
                    //Thêm các giá trị tham số (địa chỉ)
                    SqlParameter parDiaChi = new SqlParameter("@DCHI", SqlDbType.NVarChar);
                    // thêm giá trị
                    parDiaChi.Value = txtDiaChi.Text;
                    //thêm vào command
                    cmdThemKH.Parameters.Add(parDiaChi);
                    //Thêm các giá trị tham số (điểm)
                    SqlParameter parDiem = new SqlParameter("@DIEM", SqlDbType.NVarChar);
                    // thêm giá trị
                    parDiem.Value = int.Parse(txtDiem.Text.ToString());
                    //thêm vào command
                    cmdThemKH.Parameters.Add(parDiem);

                    //thực thi
                    if (cmdThemKH.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Đã thêm thành công", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Thêm khách hàng thất bại", "Thông báo");
                    }

                    dgvKhachHang.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi " + ex);
                }
                finally
                {
                    //dong ket noi
                    Reset();
                    con.Close();
                    LoadDuLieuKhachHang();
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (txtMa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMa.Focus();
            }
            else
            {
                try
                {
                    // MỞ
                    con.Open();
                    //KHAI BÁO CMD
                    SqlCommand cmdXoa = new SqlCommand();
                    cmdXoa.CommandText = "sp_XoaKH";
                    cmdXoa.CommandType = CommandType.StoredProcedure;
                    cmdXoa.Connection = con;
                    cmdXoa.Parameters.Add("@MAKH", SqlDbType.NVarChar).Value =txtMa.Text;
                    //THỰC THI
                    cmdXoa.ExecuteNonQuery();
                    dgvKhachHang.Refresh();
                    MessageBox.Show("Đã xóa khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                    //Reset();
                    LoadDuLieuKhachHang();               
                }
            }
        }
        //load dũ liệu lên các text khi chọn trong girdview
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvKhachHang.Rows[e.RowIndex];
            txtMa.Text = Convert.ToString(row.Cells["MAKH"].Value);
            txtHo.Text = Convert.ToString(row.Cells["HOKH"].Value);
            txtTen.Text = Convert.ToString(row.Cells["TENKH"].Value);
            txtSDT.Text = Convert.ToString(row.Cells["SDT"].Value);
            txtDiaChi.Text = Convert.ToString(row.Cells["DChi"].Value);
            txtDiem.Text = Convert.ToString(row.Cells["Diem"].Value);
        }
        //click reset 
        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        public void Reset()
        {

            txtDiaChi.Text = "";
            txtDiem.Text = "";
            txtHo.Text = "";
            txtTen.Text = "";
            txtSDT.Text = "";
            txtMa.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (txtMa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMa.Focus();
            }
            else if (KTThongTin())
            {
                try
            {
                con.Open();
                SqlCommand cmdSua = new SqlCommand();
                cmdSua.CommandText = "sp_SuaKH";
                cmdSua.CommandType = CommandType.StoredProcedure;
                cmdSua.Connection = con;
                cmdSua.Parameters.Add("@MAKH", SqlDbType.NVarChar).Value = txtMa.Text;
                cmdSua.Parameters.Add("@HOKH", SqlDbType.NVarChar).Value = txtHo.Text;
                cmdSua.Parameters.Add("@TENKH", SqlDbType.NVarChar).Value = txtTen.Text;
                cmdSua.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = txtSDT.Text;
                cmdSua.Parameters.Add("@DCHI", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                cmdSua.Parameters.Add("@DIEM", SqlDbType.Int).Value = int.Parse(txtDiem.Text);

                cmdSua.ExecuteNonQuery();

                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Reset();
                con.Close();
                LoadDuLieuKhachHang();
            }

          }

        }

        public bool KTThongTin()
        {
            if (txtMa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã Khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMa.Focus();
                return false;
            }

            if (txtHo.Text == "")
            {
                MessageBox.Show("Vui lòng nhập họ khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHo.Focus();
                return false;
            }
            if (txtTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên Khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTen.Focus();
                return false;
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại Khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return false;

            }
            else if (Check.CheckDigit(txtSDT.Text)== false || txtSDT.Text.Length != 10)
            {
                MessageBox.Show("Vui lòng không nhập kí tự khác ngoài kí tự số và có độ dài là 10 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return false;
            }


            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ Khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return false;
            }
            if (txtDiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập điểm Khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiem.Focus();
                return false;
            }
            return true;
        }

        private void frmThongTin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = new DialogResult();
            rs = MessageBox.Show("Bạn có muốn đóng cửa sổ quản lý khách hàng không?","Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        public static string KiTu()
        {
            char c = (char)92;
            string s = c.ToString();
            return s;
        }
    }
}

