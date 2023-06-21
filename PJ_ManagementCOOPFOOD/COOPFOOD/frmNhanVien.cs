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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        //connet sql at school
        //SqlConnection con = new SqlConnection("Data Source=MSI" + KiTu() + "SQLEXPRESS;Initial Catalog=QUANLYSTCOOPFOOD;Integrated Security=True");
        //connet sql at home
        //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=QUANLYSTCOOPFOOD;Integrated Security=True");
        //SqlConnection con = new SqlConnection("Data Source=THONGJ4" + KiTu() + "SQLEXPRESS;Initial Catalog=QUANLYSTCOOPFOOD;Integrated Security=True");

        SqlConnection con = new SqlConnection(ConnectionSQL.getConnectSQL());

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
        }
        //nut them du lieu

        //load du lieu nhan vien
        private void LoadNhanVien()
        {
            try
            {
                con.Open();
                SqlCommand cmdNhanVien = new SqlCommand();
                cmdNhanVien.CommandText = "sp_LAYDSNV";
                cmdNhanVien.CommandType = CommandType.StoredProcedure;
                cmdNhanVien.Connection = con;

                SqlDataAdapter sda = new SqlDataAdapter(cmdNhanVien);
                DataTable dtNhanVien = new DataTable();
                sda.Fill(dtNhanVien);
                dgvNhanVien.DataSource = dtNhanVien;

                dgvNhanVien.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }



        }
        //nut reset

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        // ham reset
        private void Reset()
        {
            txtCMND.Text = "";
            txtDiaChi.Text = "";
            txtHo.Text = "";
            txtTen.Text = "";
            txtPhai.Text = "";
            txtSDT.Text = "";
            txtMa.Text = "";
            dtNSinh.Text = "01/01/2000";

        }
        //nut thoat

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        //frm closing

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = new DialogResult();
            rs = MessageBox.Show("Bạn có muốn đóng cửa sổ quản lý nhân viên không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        //ham kt thong tin

        public bool KTThongTin()
        {
            if (txtMa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMa.Focus();
                return false;
            }

            if (txtHo.Text == "")
            {
                MessageBox.Show("Vui lòng nhập họ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHo.Focus();
                return false;
            }
            if (txtTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTen.Focus();
                return false;
            }
            //ngày sinh
            DateTime dtCurrent = DateTime.Now;
            if (dtCurrent.Year - dtNSinh.Value.Year < 18)
            {
                MessageBox.Show("Nhân viên chưa đủ tuổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //phái

            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return false;
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return false;

            }
            else if (Check.CheckDigit(txtSDT.Text) == false || txtSDT.Text.Length != 10)
            {
                MessageBox.Show("Vui lòng không nhập kí tự khác ngoài kí tự số và có độ dài là 10 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return false;
            }
            //cmnd
            if (txtCMND.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số CMND", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return false;
            }
            else if (Check.CheckDigit(txtCMND.Text) == false || txtCMND.Text.Length != 9)
            {
                MessageBox.Show("Vui lòng không nhập kí tự khác ngoài kí tự số và có độ dài là 9 kí tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return false;
            }


            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmMain f = new frmMain();
            if (f.getPermission() == "0")
            {
                int count = 0;
                count = dgvNhanVien.Rows.Count;
                string chuoi = "";
                int chuoi2 = 0;
                chuoi = Convert.ToString(dgvNhanVien.Rows[count - 2].Cells[0].Value);
                chuoi2 = Convert.ToInt32((chuoi.Remove(0, 2)));
                if (chuoi2 + 1 < 10)
                {
                    txtMa.Text = "NV0" + (chuoi2 + 1).ToString();
                }
                else if (chuoi2 + 1 < 100)
                {
                    txtMa.Text = "NV" + (chuoi2 + 1).ToString();
                }
                if (KTThongTin() == true)
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmdThem = new SqlCommand();
                        cmdThem.CommandText = "sp_THEMNV";
                        cmdThem.CommandType = CommandType.StoredProcedure;
                        cmdThem.Connection = con;
                        //them ma
                        SqlParameter praMa = new SqlParameter(@"MANV", SqlDbType.NVarChar);
                        praMa.Value = txtMa.Text;
                        cmdThem.Parameters.Add(praMa);
                        //ho
                        SqlParameter praHo = new SqlParameter(@"HONV", SqlDbType.NVarChar);
                        praHo.Value = txtHo.Text;
                        cmdThem.Parameters.Add(praHo);
                        //ten
                        SqlParameter praTen = new SqlParameter(@"TENNV", SqlDbType.NVarChar);
                        praTen.Value = txtTen.Text;
                        cmdThem.Parameters.Add(praTen);

                        //ngaysinh
                        SqlParameter praNS = new SqlParameter(@"NGSINH", SqlDbType.Date);
                        praNS.Value = dtNSinh.Value;
                        cmdThem.Parameters.Add(praNS);

                        //phai
                        SqlParameter praPhai = new SqlParameter(@"PHAI", SqlDbType.NVarChar);
                        praPhai.Value = txtPhai.Text;
                        cmdThem.Parameters.Add(praPhai);

                        //dia chi
                        SqlParameter praDiaChi = new SqlParameter(@"DCHI", SqlDbType.NVarChar);
                        praDiaChi.Value = txtDiaChi.Text;
                        cmdThem.Parameters.Add(praDiaChi);

                        //sdt
                        SqlParameter praSDT = new SqlParameter(@"SDT", SqlDbType.NVarChar);

                        praSDT.Value = txtSDT.Text;
                        cmdThem.Parameters.Add(praSDT);
                        //cmnd
                        SqlParameter praCMND = new SqlParameter(@"CMND", SqlDbType.NVarChar);
                        praCMND.Value = txtCMND.Text;
                        cmdThem.Parameters.Add(praCMND);

                        cmdThem.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        con.Close();
                        Reset();
                        LoadNhanVien();
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thêm nhân viên", "Thông báo");
                Reset();
            }
        }
        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvNhanVien.Rows[e.RowIndex];
            txtCMND.Text = Convert.ToString(row.Cells["CMND"].Value);
            txtDiaChi.Text = Convert.ToString(row.Cells["DCHI"].Value);
            txtHo.Text = Convert.ToString(row.Cells["HONV"].Value);
            txtMa.Text = Convert.ToString(row.Cells["MANV"].Value);
            txtPhai.Text = Convert.ToString(row.Cells["PHAI"].Value);
            txtSDT.Text = Convert.ToString(row.Cells["SDT"].Value);
            txtTen.Text = Convert.ToString(row.Cells["TENNV"].Value);
            dtNSinh.Text = Convert.ToString(row.Cells["NGSINH"].Value);
            //int i;
            //i = dgvNhanVien.CurrentRow.Index;
            //txtMa.Text = dgvNhanVien.Rows[i].Cells[0].Value.ToString();
            //txtHo.Text = dgvNhanVien.Rows[i].Cells[1].Value.ToString();
            //txtTen.Text = dgvNhanVien.Rows[i].Cells[2].Value.ToString();
            //dtNSinh.Text = dgvNhanVien.Rows[i].Cells[3].Value.ToString();
            //txtPhai.Text = dgvNhanVien.Rows[i].Cells[4].Value.ToString();
            //txtDiaChi.Text = dgvNhanVien.Rows[i].Cells[5].Value.ToString();
            //txtSDT.Text = dgvNhanVien.Rows[i].Cells[6].Value.ToString();
            //txtCMND.Text = dgvNhanVien.Rows[i].Cells[7].Value.ToString();


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //frmMain f = new frmMain();
            //if (f.getPermission() == "admin")
            //{


                try
                {
                    con.Open();
                    SqlCommand cmdSua = new SqlCommand();
                    cmdSua.CommandText = "sp_SUANV";
                    cmdSua.CommandType = CommandType.StoredProcedure;
                    cmdSua.Connection = con;
                    cmdSua.Parameters.Add(@"MANV", SqlDbType.NChar).Value = txtMa.Text;
                    cmdSua.Parameters.Add(@"HONV", SqlDbType.NChar).Value = txtHo.Text;
                    cmdSua.Parameters.Add(@"TENNV", SqlDbType.NChar).Value = txtTen.Text;
                    cmdSua.Parameters.Add(@"PHAI", SqlDbType.NChar).Value = txtPhai.Text;
                    cmdSua.Parameters.Add(@"NGSINH", SqlDbType.Date).Value = dtNSinh.Value;
                    cmdSua.Parameters.Add(@"DCHI", SqlDbType.NChar).Value = txtDiaChi.Text;
                    cmdSua.Parameters.Add(@"SDT", SqlDbType.NChar).Value = txtSDT.Text;
                    cmdSua.Parameters.Add(@"CMND", SqlDbType.NChar).Value = txtCMND.Text;
                    cmdSua.ExecuteNonQuery();
                    MessageBox.Show("Sửa thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();
                    Reset();
                    LoadNhanVien();
                }
            //}
            //else
            //{
            //    MessageBox.Show("Bạn không có quyền sửa nhân viên", "Thông báo");
            //    Reset();
            //}
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //frmMain f = new frmMain();

            //if (f.getPermission() == "admin")
            //{


                if (txtMa.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMa.Focus();
                }
                else
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmdXoa = new SqlCommand();
                        cmdXoa.CommandText = "sp_XOANV";
                        cmdXoa.CommandType = CommandType.StoredProcedure;
                        cmdXoa.Connection = con;
                        cmdXoa.Parameters.Add(@"MANV", SqlDbType.NVarChar).Value = txtMa.Text;
                        cmdXoa.ExecuteNonQuery();
                        MessageBox.Show("Đã xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        con.Close();
                        Reset();
                        LoadNhanVien();
                    }

                }
            //}
            //else
            //{
            //    MessageBox.Show("Bạn không có quyền xóa nhân viên", "Thông báo");
            //    Reset();
            //}
        }
        
    }
}
