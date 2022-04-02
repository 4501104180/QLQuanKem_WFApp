using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IceCreamManage
{
    public partial class fFacebook : Form
    {
        public fFacebook()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txbAccountName.Text == null || txbAccountName.Text == "")
            {
                MessageBox.Show("Không được để trống tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txbPassword.Text == null || txbPassword.Text == "")
            {
                MessageBox.Show("Không được để trống mất khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Program.X = @"https://www.facebook.com/";
                new Facebook().ShowDialog();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llabelForgotpassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Chức năng này hiện đang bảo trì !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void pbUnHide_Click(object sender, EventArgs e)
        {
            if (txbPassword.UseSystemPasswordChar == true)
            {
                pbHide.BringToFront();
                txbPassword.UseSystemPasswordChar = false;
            }
        }
        private void pbHide_Click(object sender, EventArgs e)
        {
            if (txbPassword.UseSystemPasswordChar == false)
            {
                pbUnHide.BringToFront();
                txbPassword.UseSystemPasswordChar = true;
            }
        }

        private void txbPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pcbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
