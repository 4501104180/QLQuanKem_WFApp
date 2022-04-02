using IceCreamManage.DAO;
using IceCreamManage.DTO;
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
    public partial class fForgotPassword : Form
    {
        public fForgotPassword()
        {
            InitializeComponent();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void UpdateAccountInfo()
        {
            string userName = txbUserName.Text;
            string newpass = txbNewPassword.Text;
            string reenterPass = txbReEnterPassword.Text;
            string password2 = txbPassword2.Text;
            if (!newpass.Equals(reenterPass))
            {
                MessageBox.Show("Please re-enter the correct password with the new password!", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (newpass == "" || newpass == null || reenterPass == null || reenterPass == "")
            {

                MessageBox.Show("Password must not be empty", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (AccountDAO.Instance.ForgotPassword(userName,newpass,password2))
                {
                    MessageBox.Show("Password change succeeded", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please enter the correct password level 2 !", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }
        private void pbUnHide_Click(object sender, EventArgs e)
        {
            if (txbNewPassword.UseSystemPasswordChar == true || txbReEnterPassword.UseSystemPasswordChar == true || txbPassword2.UseSystemPasswordChar == true)
            {
                pbHide.BringToFront();
                txbNewPassword.UseSystemPasswordChar = false;
                txbReEnterPassword.UseSystemPasswordChar = false;
                txbPassword2.UseSystemPasswordChar = false;
            }
        }

        private void pbHide_Click(object sender, EventArgs e)
        {
            if (txbNewPassword.UseSystemPasswordChar == false || txbReEnterPassword.UseSystemPasswordChar == false || txbPassword2.UseSystemPasswordChar == false)
            {
                pbUnHide.BringToFront();
                txbNewPassword.UseSystemPasswordChar = true;
                txbReEnterPassword.UseSystemPasswordChar = true;
                txbPassword2.UseSystemPasswordChar = true;
            }
        }

        private void pcbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
