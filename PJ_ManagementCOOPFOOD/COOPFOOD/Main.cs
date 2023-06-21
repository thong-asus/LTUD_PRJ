using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace COOPFOOD
{
    public partial class frmMain : Form
    {
        private string username = "", password = "";
        private string permission = "";
        public frmMain(string username, string password, string permission)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.permission = permission;
        }
        public frmMain()
        {
            InitializeComponent();
        }
        public string getPermission()
        {
            return permission;
        }
        bool isExit = true;

        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            currentFormChild = childForm;
            childForm.Show();
            childForm.MdiParent = this;

        }
        string thongBao = "Bạn không có quyền truy cập vào mục này!!!";
        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
                OpenChildForm(new frmHoaDon());                
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang());
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (permission == "0")
            {
                OpenChildForm(new frmNhanVien());
            }
            else
            {
                MessageBox.Show(thongBao,"Thông báo");
            }
            
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (permission == "0")
            {
                OpenChildForm(new frmNhaCungCap());
            }
            else
            {
                MessageBox.Show(thongBao, "Thông báo");
            }
        }

        private void quảnLýHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (permission == "0")
            {
                OpenChildForm(new frmHangHoa());
            }
            else
            {
                MessageBox.Show(thongBao, "Thông báo");
            }
            
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rs = new DialogResult();
            rs = MessageBox.Show("Bạn có muốn đóng chương trình quản lý Siêu Thị COOP-FOOD không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (rs == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (permission == "0")
            {
                OpenChildForm(new frm_XemDSKH_rpt());
            }
            else
            {
                MessageBox.Show(thongBao, "Thông báo");
            }
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (permission == "0")
            {
                OpenChildForm(new frm_XemDSNV_rpt());
            }
            else
            {
                MessageBox.Show(thongBao, "Thông báo");
            }
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (permission == "0")
            {
                OpenChildForm(new frm_XemDSHangHoa_rpt());
            }
            else
            {
                MessageBox.Show(thongBao, "Thông báo");
            }
        }

        private void nhàCungCấpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (permission == "0")
            {
                OpenChildForm(new frm_XemDSNhaCungCap_rpt());
            }
            else
            {
                MessageBox.Show(thongBao, "Thông báo");
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isExit = false;
            this.Close();
            frmLogin f = new frmLogin();
            f.Show();
        }
    }
}
