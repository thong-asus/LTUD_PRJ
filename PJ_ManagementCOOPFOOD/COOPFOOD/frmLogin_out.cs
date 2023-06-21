using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace COOPFOOD
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(ConnectionSQL.getConnectSQL());
        private void btn_login_Click(object sender, EventArgs e)
        {
            if (ChkText() == false)
            {
                MessageBox.Show("Vui lòng nhập tài khoản mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "sp_LOGIN";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@USERNAME", SqlDbType.VarChar).Value = txt_username.Text;
                    cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = txt_password.Text;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        //MessageBox.Show(dt.Rows[0][2].ToString());
                        frmMain f = new frmMain(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_password.Text = "";
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }

            }

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private bool ChkText()
        {
            if (txt_username.Text == "")
            {
                return false;
            }
            if (txt_password.Text == "")
            {
                return false;
            }
            return true;
        }

        private void chk_apear_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_apear.Checked)
            {
                txt_password.PasswordChar = '\0';
            }
            else
            {
                txt_password.PasswordChar = '*';
            }
        }
    }
}
