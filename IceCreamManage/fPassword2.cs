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
    public partial class fPassword2 : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        public fPassword2(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }
        void ChangeAccount(Account acc)
        {
            txbUserName.Text = LoginAccount.UserName;
        }

        void UpdateAccountInfo()
        {
            string userName2 = txbUserName.Text;
            string password2 = txbPassword2.Text;
            string newpass2 = txbNewPassword2.Text;
            string reenterPass2 = txbReEnterPassword2.Text;
            if (!newpass2.Equals(reenterPass2))
            {
                MessageBox.Show("Please re-enter the correct password with the new password!", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (newpass2 == "" || reenterPass2 == "")
            {

                MessageBox.Show("New password must not be empty", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (AccountDAO.Instance.ChangePassword2(userName2, password2, newpass2))
                {
                    MessageBox.Show("Password change succeeded", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please enter the correct password level 2", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        private void pbUnHide_Click(object sender, EventArgs e)
        {
            if (txbPassword2.UseSystemPasswordChar == true || txbNewPassword2.UseSystemPasswordChar == true || txbReEnterPassword2.UseSystemPasswordChar == true)
            {
                pbHide.BringToFront();
                txbPassword2.UseSystemPasswordChar = false;
                txbNewPassword2.UseSystemPasswordChar = false;
                txbReEnterPassword2.UseSystemPasswordChar = false;
            }
        }

        private void pbHide_Click(object sender, EventArgs e)
        {
            if (txbPassword2.UseSystemPasswordChar == false || txbNewPassword2.UseSystemPasswordChar == false || txbReEnterPassword2.UseSystemPasswordChar == false)
            {
                pbUnHide.BringToFront();
                txbPassword2.UseSystemPasswordChar = true;
                txbNewPassword2.UseSystemPasswordChar = true;
                txbReEnterPassword2.UseSystemPasswordChar = true;
            }
        }

        private void pcbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
