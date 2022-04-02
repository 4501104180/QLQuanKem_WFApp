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
    public partial class fPassword : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        public fPassword(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }

        void ChangeAccount(Account acc)
        {
            txbUserName.Text = LoginAccount.UserName;
        }

        //Hàm cập nhật mật khẩu mới
        void UpdateAccountInfo()
        {
            string userName = txbUserName.Text;
            string password = txbPassword.Text;
            string newpass = txbNewPassword.Text;
            string reenterPass = txbReEnterPassword.Text;
            if (!newpass.Equals(reenterPass))
            {
                MessageBox.Show("Please re-enter the correct password with the new password!", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (newpass == "" || newpass == null || reenterPass == null || reenterPass == "")
            {

                MessageBox.Show("New password must not be empty", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (AccountDAO.Instance.ChangePassword(userName, password, newpass))
                {
                    MessageBox.Show("Password change succeeded", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please enter the correct password", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        //Click _ nút Save Change
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        //Click _ Hiện mật khẩu
        private void pbUnHide_Click(object sender, EventArgs e)
        {
            if (txbPassword.UseSystemPasswordChar == true || txbNewPassword.UseSystemPasswordChar == true || txbReEnterPassword.UseSystemPasswordChar == true)
            {
                pbHide.BringToFront();
                txbPassword.UseSystemPasswordChar = false;
                txbNewPassword.UseSystemPasswordChar = false;
                txbReEnterPassword.UseSystemPasswordChar = false;
            }
        }

        //Click _ Ẩn mật khẩu
        private void pbHide_Click(object sender, EventArgs e)
        {
            if (txbPassword.UseSystemPasswordChar == false || txbNewPassword.UseSystemPasswordChar == false || txbReEnterPassword.UseSystemPasswordChar == false)
            {
                pbUnHide.BringToFront();
                txbPassword.UseSystemPasswordChar = true;
                txbNewPassword.UseSystemPasswordChar = true;
                txbReEnterPassword.UseSystemPasswordChar = true;
            }
        }

        //Click _ close
        private void pcbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Click _ Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Chuyển qua form Change Password level 2
        private void labelPassword2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fPassword2 fPassword2 = new fPassword2(LoginAccount);
            this.Hide();
            fPassword2.ShowDialog();
        }
    }
}
